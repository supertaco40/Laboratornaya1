using System;

namespace calc
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arg = "\n\t\r,\\/\'\f";
            var separateArgs = new [] {',', '\n', '\t', '\r', '\\', '/', '\'', '\f'};
            var result = Calc.Add(arg, separateArgs);
        }
    }
}