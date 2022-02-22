using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GhettoASM
{
    public class mem
    {
        //instruction pointer
        public static long ip = 0;

        //return pointer-chain
        public static Stack<long> retc = new Stack<long>();

        //flags
        public struct flags
        {
            public static int cmp = 0;  //last cmp result
        }

        //registers
        public static long r1 = 0;                              
        public static long r2 = 0;
        public static long r3 = 0;
        public static long r4 = 0;
        public static long r5 = 0;
        public static long r6 = 0;
        public static long r7 = 0;
        public static long r8 = 0;
        public static long r9 = 0;

        public static long _read_register(string reg)
        {
            FieldInfo register = utils.register_by_name(reg.ToLower());
            if (register == null)
                return 0;

            return (long)register.GetValue(null);
        }

        public static void _write_register(string reg, long val)
        {
            FieldInfo register = utils.register_by_name(reg.ToLower());
            if (register == null)
                return;

            register.SetValue(null, val);
        }

        public static string dump_raw()
        {
            string dump = "";

            dump += "Registers:\n";
            dump += "IP: " + ip + "\n";
            dump += "R1: " + r1 + "\n";
            dump += "R2: " + r2 + "\n";
            dump += "R3: " + r3 + "\n";
            dump += "R4: " + r4 + "\n";
            dump += "R5: " + r5 + "\n";
            dump += "R6: " + r6 + "\n";
            dump += "R7: " + r7 + "\n";
            dump += "R8: " + r8 + "\n";
            dump += "R9: " + r9 + "\n";
            dump += "\n";
            dump += "Flags: " + "\n";
            dump += "cmp: " + mem.flags.cmp + "\n";
            dump += "\n";
            dump += "Return: " + ((retc.Count > 0) ? retc.Last() : -1);

            return dump;
        }

        public static void dump_to_file()
        {
            File.WriteAllText("memdump.txt", "");

            File.AppendAllText("memdump.txt", "Registers:\n");

            File.AppendAllText("memdump.txt", "IP: " + ip + "\n");
            File.AppendAllText("memdump.txt", "R1: " + r1 + "\n");
            File.AppendAllText("memdump.txt", "R2: " + r2 + "\n");
            File.AppendAllText("memdump.txt", "R3: " + r3 + "\n");
            File.AppendAllText("memdump.txt", "R4: " + r4 + "\n");
            File.AppendAllText("memdump.txt", "R5: " + r5 + "\n");
            File.AppendAllText("memdump.txt", "R6: " + r6 + "\n");
            File.AppendAllText("memdump.txt", "R7: " + r7 + "\n");
            File.AppendAllText("memdump.txt", "R8: " + r8 + "\n");
            File.AppendAllText("memdump.txt", "R9: " + r9 + "\n");

            File.AppendAllText("memdump.txt", "\n\n");

            File.AppendAllText("memdump.txt", "Flags:\n");
            File.AppendAllText("memdump.txt", "cmp:" + mem.flags.cmp + "\n");
        }

        public static void reset()
        {
            //generals
            ip = 0;
            retc = new Stack<long>();

            //flags
            flags.cmp = 0;

            //registers
            r1 = 0;
            r2 = 0;
            r3 = 0;
            r4 = 0;
            r5 = 0;
            r6 = 0;
            r7 = 0;
            r8 = 0;
            r9 = 0;
        }
    }
}
