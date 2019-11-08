using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Wrappers
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void Write(string str)
        {
            Console.Write(str);
        }
    }
}
