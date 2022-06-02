using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GhettoASM
{
    public static class mem
    {
        public static long[] registers = new long[20];
        public static byte[] ram = new byte[1024 * 8];
        public static bool[] ram_free_map = new bool[1024 * 128];

        //instruction pointer
        public static long ip = 1;

        //return pointer-chain
        public static Stack<long> retc = new Stack<long>();

        //flags
        public struct flags
        {
            public static int cmp = 0;  //last cmp result
        }

        public static T _read_ram<T>(long ptr)
        {
            Type type = typeof(T);
            if (type == typeof(long))
            {
                return (T)Convert.ChangeType(ram_manager._read_long(ptr), typeof(long));
            }

            throw new Exception();
        }

        public static bool _write_ram<T>(long ptr, T val)
        {
            Type type = typeof(T);
            if(type == typeof(long))
            {
                ram_manager._write_long(ptr, (long)Convert.ChangeType(val, typeof(long)));
                return true;
            }

            return false;
        }

        public static long _read_register(string reg)
        {
            int target = int.Parse(reg.Substring(1));
            return registers[target];
        }

        public static void _write_register(string reg, long val)
        {
            int target = int.Parse(reg.Substring(1));
            registers[target] = val;
        }

        public static string dump_raw()
        {
            string dump = "";

            dump += "Registers:\n";
            dump += "IP: " + ip + "\n";
            for(int i = 0; i < registers.Length; i++)
            {
                dump += "R" + i + ": " + registers[i] + "\n";
            }
            dump += "\n";
            dump += "Flags: " + "\n";
            dump += "cmp: " + mem.flags.cmp + "\n";
            dump += "\n";
            dump += "Return: " + ((retc.Count > 0) ? retc.Last() : -1);

            return dump;
        }

        public static void dump_to_file()
        {
            File.WriteAllText("memdump.txt", dump_raw());
        }

        public static void reset()
        {
            //generals
            ip = 1;
            retc = new Stack<long>();

            //flags
            flags.cmp = 0;

            mem.registers = new long[20];
            mem.ram = new byte[1024 * 8];
            mem.ram_free_map = new bool[1024 * 128];

            //make all the bytes status "free"
            for (int i = 0; i < ram_free_map.Length; i++)
                ram_free_map[i] = true;
        }
    }

    public static class ram_manager
    {
        public static long find_free_ram()
        {
            for(int i = 0; i < mem.ram.Length; i += 8)
            {
                if (mem.ram_free_map[i] == true)
                    return i;
            }

            throw new Exception("Could not find free ram.");
        }

        public static long _read_long(long ptr)
        {
            int size = GlobalExtensions.SizeOf<long>();
            byte[] raw_val = new byte[size];

            for (int i = 0; i < size; i++)
            {
                raw_val[i] = mem.ram[ptr + i];
            }

            return (long)BitConverter.ToUInt64(raw_val, 0);
        }

        public static bool _write_long(long ptr, long val)
        {
            int size = GlobalExtensions.SizeOf<long>();
            byte[] raw_val = BitConverter.GetBytes(val);

            for (int i = 0; i < size - 1; i++)
            {
                mem.ram[ptr + i] = raw_val[i];
                mem.ram_free_map[ptr + i] = false;
            }

            return false;
        }
    }

    internal static class GlobalExtensions
    {
        public static int SizeOf<T>()
        {
            return SizeOf(typeof(T));
        }

        public static int SizeOf(this Type type)
        {
            var dynamicMethod = new DynamicMethod("SizeOf", typeof(int), Type.EmptyTypes);
            var generator = dynamicMethod.GetILGenerator();

            generator.Emit(OpCodes.Sizeof, type);
            generator.Emit(OpCodes.Ret);

            var function = (Func<int>)dynamicMethod.CreateDelegate(typeof(Func<int>));
            return function();
        }
    }
}
