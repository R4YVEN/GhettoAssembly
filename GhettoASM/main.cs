using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GhettoASM
{
    public static class main
    {
        public static bool exec_instruction(Instruction ins)
        {
            try
            {
                switch (ins.op)
                {
                    case OP.MOV:
                        long mov_val = 0;
                        if ((utils.is_arg_register(ins.arguments[1]))) 
                            mov_val = mem._read_register(ins.arguments[1]);
                        else if (ins.arguments[1].StartsWith("$")) 
                            mov_val = mem._read_ram<long>(long.Parse(ins.arguments[1].Substring(1)));
                        else 
                            mov_val = long.Parse(ins.arguments[1]);

                        if (utils.is_arg_register(ins.arguments[0]))
                        {
                            mem._write_register(ins.arguments[0], mov_val);
                            break;
                        }

                        if (ins.arguments[0].StartsWith("$"))
                        {
                            mem._write_ram<long>(long.Parse(ins.arguments[0].Substring(1)), mov_val);
                            break;
                        }

                        if (ins.arguments[0].StartsWith("["))
                        {
                            mem._write_ram<long>(mem._read_register(ins.arguments[0].Substring(1).Trim(']')), mov_val);
                        }
                        break;
                    case OP.ADD:
                        mem._write_register(ins.arguments[0], mem._read_register(ins.arguments[0]) + (utils.is_arg_register(ins.arguments[1]) ? mem._read_register(ins.arguments[1]) : long.Parse(ins.arguments[1])));
                        break;
                    case OP.SUB:
                        mem._write_register(ins.arguments[0], mem._read_register(ins.arguments[0]) - (utils.is_arg_register(ins.arguments[1]) ? mem._read_register(ins.arguments[1]) : long.Parse(ins.arguments[1])));
                        break;
                    case OP.PRNT:
                        if (ins.arguments[0].StartsWith("$"))
                        {
                            utils.print("" + mem._read_ram<long>(long.Parse(ins.arguments[0].Substring(1))));
                            break;
                        }
                        else if ((utils.is_arg_register(ins.arguments[0])))
                        {
                            utils.print("" + mem._read_register(ins.arguments[0]));
                            break;
                        }

                        utils.print(ins.arguments[0].Replace("\\n", "\n"));
                        break;
                    case OP.PRNTR:
                        utils.print("" + mem._read_register(ins.arguments[0]));
                        break;
                    case OP.CMP:
                        long val1 = (utils.is_arg_register(ins.arguments[0]) ? mem._read_register(ins.arguments[0]) : long.Parse(ins.arguments[0]));
                        long val2 = (utils.is_arg_register(ins.arguments[1]) ? mem._read_register(ins.arguments[1]) : long.Parse(ins.arguments[1]));
                        mem.flags.cmp = (val1 == val2) ? 0 : 1;
                        break;
                    case OP.JMP:
                        {
                            if (ins.arguments[0].StartsWith("."))
                            {
                                long tptr;
                                if (long.TryParse(ins.arguments[0].Substring(1), out tptr))
                                {
                                    mem.retc.Push(mem.ip);
                                    mem.ip = tptr - 1;
                                    break;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            Label label = utils.find_label(ins.arguments[0].Replace("#", "").Replace(":", ""));
                            if (label.pointer != -1)
                            {
                                mem.retc.Push(mem.ip);
                                mem.ip = label.pointer;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        break;
                    case OP.JE:
                        {
                            if (mem.flags.cmp == 0)
                            {
                                if (ins.arguments[0].StartsWith("$"))
                                {
                                    long tptr;
                                    if (long.TryParse(ins.arguments[0].Substring(1), out tptr))
                                    {
                                        mem.retc.Push(mem.ip);
                                        mem.ip = tptr - 1;
                                        break;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                Label label = utils.find_label(ins.arguments[0].Replace("#", "").Replace(":", ""));
                                if (label.pointer != -1)
                                {
                                    mem.retc.Push(mem.ip);
                                    mem.ip = label.pointer;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                        }
                        break;
                    case OP.JNE:
                        {
                            if (mem.flags.cmp == 1)
                            {
                                if (ins.arguments[0].StartsWith("$"))
                                {
                                    long tptr;
                                    if (long.TryParse(ins.arguments[0].Substring(1), out tptr))
                                    {
                                        mem.retc.Push(mem.ip);
                                        mem.ip = tptr - 1;
                                        break;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                Label label = utils.find_label(ins.arguments[0].Replace("#", "").Replace(":", ""));
                                if (label.pointer != -1)
                                {
                                    mem.retc.Push(mem.ip);
                                    mem.ip = label.pointer;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                        }
                        break;
                    case OP.RET:
                        mem.ip = mem.retc.Pop();
                        break;
                    case OP.INPT:
                        long input = long.Parse(Console.ReadLine());
                        Console.CursorTop--; //prevent console from making new line after input
                        mem._write_register(ins.arguments[0], input);
                        break;
                    case OP.FFMEM:
                        mem._write_register("R19", ram_manager.find_free_ram());
                        break;
                }

                return true;
            }
            catch (Exception e)
            {
                utils.print("[ERROR] Could not execute on line: " + ins.pointer + "\nDetails: " + e.Message);
                return false;
            }
        }

        public static void load_prog(List<string> code)
        {
            G.raw_prog = code;

            G.prog.Clear();
            G.prog.Add(new Instruction()); //for indexing

            int i = 0;
            foreach (string line in G.raw_prog)
            {
                i++;
                try
                {
                    if (line.Length < 3)
                    {
                        G.prog.Add(new Instruction(i, OP.NOP, null));
                        continue;
                    }

                    if (line.StartsWith("#"))
                    {
                        Label label = new Label();
                        label.name = line.Substring(1).Replace(":", "").Trim();
                        label.pointer = i;

                        G.labels.Add(label);
                        G.prog.Add(new Instruction(i, OP.NOP, null));
                        continue;
                    }

                    Instruction instruction = new Instruction();
                    instruction.pointer = i;
                    instruction.op = utils.op_by_name(line.Split(' ')[0].Trim());

                    if (line.Split(' ').Length > 1) instruction.arguments = utils.str_to_args(line.Substring(line.Split(' ')[0].Length + 1).Trim());
                    else instruction.arguments = null;

                    G.prog.Add(instruction);
                }
                catch
                {
                    utils.print("[ERROR] Could not interpret line: " + i + "\n");
                }
            }
        }

        public static void exec_prog()
        {
            while (mem.ip < G.prog.Count())
            {
                if (mem.ip > G.prog.Count - 1)
                    goto exit;

                if (G.prog[(int)mem.ip].op == OP.EXIT)
                    goto exit;

                if (G.prog[(int)mem.ip].op != OP.NOP)
                {
                    Instruction ins = G.prog[(int)mem.ip];
                    if (!GhettoASM.main.exec_instruction(ins))
                        goto exit;
                }

                mem.ip++;
            }

        exit:
            Environment.Exit(0);
        }
    }
}