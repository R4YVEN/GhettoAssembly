using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GhettoASM
{
    internal class utils
    {
        public static void set_print_func(MethodInfo method)
        {
            if (method != null)
                G.printfunc = method;
        }

        public static void print(string str)
        {
            if (G.printfunc != null)
                G.printfunc.Invoke(null, new object[] { str });
            else
                Console.WriteLine(str);
        }

        public static string[] str_to_args(string args)
        {
            if (args.StartsWith("\"") && args.EndsWith("\""))
            {
                args = utils.parse_str(args);
                return new string[] { args };
            }
            else
            {
                return args.Replace(" ", "").Split(','); //fixes spacing issue in one weird oneliner.. wtf??
            }
        }

        public static OP op_by_name(string str)
        {
            foreach (OP op in Enum.GetValues(typeof(OP)))
            {
                if (Enum.GetName(typeof(OP), op) == str.Trim())
                    return op;
            }

            throw new Exception();  //make it clear to user that some line cant be interpreted
        }

        public static Label label_by_pointer(int ptr)
        {
            foreach (Label label in G.labels)
            {
                if (ptr == label.pointer)
                    return label;
            }

            throw new Exception();  //make it clear to user that some line cant be interpreted
        }

        public static Label find_label(string name)
        {
            foreach (Label label in G.labels)
            {
                if (name == label.name)
                {
                    return label;
                }
            }

            return new Label(-1);  //make it clear to user that some line cant be interpreted
        }

        public static string parse_str(string arg)
        {
            //TODO: Implement proper checks and string-formatting
            arg = arg.Remove(0, 1);
            arg = arg.Remove(arg.Length - 1, 1);

            return arg;
        }

        public static Instruction str_to_instruction(string line)
        {
            Instruction instruction = new Instruction();
            instruction.op = utils.op_by_name(line.Split(' ')[0]);
            instruction.arguments = line.Substring(line.Split(' ')[0].Length + 1).Replace(" ", "").Split(','); //fixes spacing issue in one weird oneliner.. i dont even know what i did here??

            return instruction;
        }

        public static bool is_arg_register(string arg)
        {
            try
            {
                if (arg.ToLower()[0] == 'r')
                {
                    int target = int.Parse(arg.Substring(1));
                    if (mem.registers.Length >= target - 1)
                        return true;
                }
            }
            catch { }

            return false;
        }

        public static bool is_arg_label(string arg)
        {
            if (utils.find_label(arg.ToLower()).pointer != -1)
                return true;
            else
                return false;
        }
    }

    public static class serializer
    {
        public static byte[] serialize_prog()
        {
            GAObject gaobj = new GAObject(G.prog, G.labels);
            gaobj.prog = G.prog.ToArray();
            gaobj.labels = G.labels.ToArray();
            byte[] raw_gaobj = serialize_gaobj(gaobj);

            //details, versioning etc later. only serializing for now

            return raw_gaobj;
        }

        public static byte[] serialize_gaobj(GAObject gaobj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, gaobj);
                return ms.ToArray();
            }
        }

        public static GAObject deserialize_gaobj(byte[] bytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(bytes, 0, bytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = (GAObject)binForm.Deserialize(memStream);
                return obj;
            }
        }
    }
}
