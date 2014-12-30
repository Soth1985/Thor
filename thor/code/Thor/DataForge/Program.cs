using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Thor.DataForge;

namespace DataForge
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You must supply path to project file");
                return;
            }

            string templateGroupPath = Directory.GetCurrentDirectory();

            if (args.Length > 1)
            {
                templateGroupPath = args[1];
            }
            else
            {
                Console.WriteLine("You must supply path to templates file");
                return;
            }

            Compiler.Instance.LoadTemplateGroup(Path.Combine(templateGroupPath,"DataForge.stg"));

            string path = args[0];
            string workDir = Path.GetDirectoryName(path);
            Directory.SetCurrentDirectory(workDir);
            Compiler.Instance.BuildProject(Path.GetFileName(path));
        }
    }
}
