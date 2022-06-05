using System;
using static System.Int64;

namespace calc
{
    public static class Calc
    {
        public const char BaseSeparator = ','; private const char AnotherSeparator = '\n'; private const string EmptyString = "";

        public const string InvalidStringMessage = "Invalid args string"; public const string InvalidSeparatorsMessage = "Invalid separators";
        public const string NumbersBellowZeroMessage = "Numbers bellow zero"; public static int Add(string args)
        {
            var separators = new[] { AnotherSeparator, BaseSeparator }; return Add(args, separators);
        }

        public static int Add(string args, char[] separators)
        {
            if (separators.Length == 0) throw new ArgumentException(InvalidSeparatorsMessage);

            var argsArray = args.Split(separators); if (argsArray.Length == 0) throw new
            ArgumentException(InvalidStringMessage); var result = 0;
            foreach (var arg in argsArray)
            {

                if (arg == EmptyString) throw new ArgumentException(InvalidStringMessage);

                if (!TryParse(arg, out var number)) throw new ArgumentException(InvalidStringMessage);
                if (number < 0) throw new ArgumentException(NumbersBellowZeroMessage);

                result += (int)number;
            }

            return result;
        }
    }
}
