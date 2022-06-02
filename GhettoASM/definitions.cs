using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GhettoASM
{
    [Serializable]
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
        PRNTR,  //deprecated and useless since normal PRNT can output registers too.
        INPT,   //cant be used in the IDE as of now
        FFMEM   //find free memory and store its address in R19
    };

    [Serializable]
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

    [Serializable]
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

    [Serializable]
    public struct GAObject
    {
        public Instruction[] prog;
        public Label[] labels;

        public GAObject(List<Instruction> _prog, List<Label> _labels)
        {
            prog = _prog.ToArray();
            labels = _labels.ToArray();
        }
    }

    public static class G
    {
        public static List<string> raw_prog = new List<string>();
        public static List<Instruction> prog = new List<Instruction>() { new Instruction() };
        public static List<Label> labels = new List<Label>();

        //public static mem mem = new mem();

        public static MethodInfo printfunc = null;

        public static void reset_prog()
        {
            //reset program
            G.prog = new List<Instruction>() { new Instruction() };
            G.raw_prog = new List<string>() { };
            G.labels = new List<Label>() { };
        }
    }
}
