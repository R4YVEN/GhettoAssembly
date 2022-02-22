using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GhettoASM
{
    public enum OP
    {
        NOP,
        EXIT,
        MOV,
        ADD,
        SUB,
        CMP,
        JMP,
        JE,
        JNE,
        RET,
        PRNT,
        PRNTR,
        INPT
    };

    public struct Instruction
    {
        public int pointer;
        public OP op;
        public string[] arguments;

        public Instruction(int _pointer, OP _op, string[] _args)
        {
            pointer = _pointer;
            op = _op;
            arguments = _args;
        }
    }

    public struct Label
    {
        public int pointer;
        public string name;

        public Label(int _pointer)
        {
            pointer = _pointer;
            name = "";
        }
    }

    public static class G
    {
        public static List<string> raw_prog = new List<string>();
        public static List<Instruction> prog = new List<Instruction>() { new Instruction() };
        public static List<Label> labels = new List<Label>();

        public static mem mem = new mem();

        public static MethodInfo printfunc = null;
    }
}
