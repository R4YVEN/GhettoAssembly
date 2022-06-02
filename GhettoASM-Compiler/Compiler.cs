using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GhettoASM_Compiler
{
    public static class Compiler
    {
        public static int compile_with_cs(string dest, byte[] stub)
        {
            try
            {
                byte[] compiled_prog = GhettoASM.serializer.serialize_prog();

                AssemblyDef asm = AssemblyDef.Load(stub);
                asm.ManifestModule.Resources.Add(new EmbeddedResource("compiled", compiled_prog, ManifestResourceAttributes.Public));
                asm.Write(dest);

                return 0;
            }
            catch { return -1; }
        }
    }
}
