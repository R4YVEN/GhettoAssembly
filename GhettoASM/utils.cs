using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static FieldInfo register_by_name(string str)
        {
            FieldInfo[] memoryfields = typeof(mem).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo field in memoryfields)
            {
                if (field.Name == str)
                    return field;
            }

            return null;
        }

        public static OP op_by_name(string str)
        {
            foreach (OP op in Enum.GetValues(typeof(OP)))
            {
                if (Enum.GetName(typeof(OP), op) == str)
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

            return new Label(-1);
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

            return new Label(-1);
        }

        public static string parse_str(string arg)
        {
            //Implement proper checks and string-formatting
            arg = arg.Remove(0, 1);
            arg = arg.Remove(arg.Length - 1, 1);

            return arg;
        }

        public static Instruction str_to_instruction(string line)
        {
            Instruction instruction = new Instruction();
            instruction.op = utils.op_by_name(line.Split(' ')[0]);
            instruction.arguments = line.Substring(line.Split(' ')[0].Length + 1).Replace(" ", "").Split(','); //fixes spacing issue in one weird oneliner.. wtf??

            return instruction;
        }

        public static bool is_arg_register(string arg)
        {
            if (utils.register_by_name(arg.ToLower()) != null)
                return true;
            else
                return false;
        }
    }
}
