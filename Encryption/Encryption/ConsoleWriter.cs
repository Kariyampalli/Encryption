using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    internal class ConsoleWriter
    {
        public void Write(string output, ConsoleColor color)
        {
            if(output != null)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(output);
            }
            else
            {
                Console.ForegroundColor = color;
                Console.WriteLine("!!!!!!!!!Console Writer received null!!!!!!!!!!");
            }
        }
    }
}
