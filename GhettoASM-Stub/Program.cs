using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GhettoASM;
using GhettoASM_Stub.Properties;

namespace GhettoASM_Stub
{
    internal class Program
    {
        public static bool currentlyExecuting = false;
        public static bool stopExecuting = false;

        static void Main(string[] args)
        {
            //initialize
            Stream compiledStream =  Assembly.GetExecutingAssembly().GetManifestResourceStream("compiled");
            MemoryStream reader = new MemoryStream();
            compiledStream.CopyTo(reader);
            if (compiledStream.Length < 1)
            {
                Console.WriteLine("[GhettoASM] Empty program-buffer. This is likely the result of a compiler error.");
                Environment.Exit(-1);
            }

            //manually load the program from gaobj
            GAObject gaobj = GhettoASM.serializer.deserialize_gaobj(reader.ToArray());
            G.prog = gaobj.prog.ToList();
            G.labels = gaobj.labels.ToList();
            G.printfunc = typeof(Program).GetMethod("DebugLog");

            //execute
            main.exec_prog();
        }

        public static void DebugLog(string msg)
        {
            Console.Write(msg);
        }
    }
}
