using System;
using System.Threading.Tasks;

namespace ConsoleChatApp
{
    public static class ConsoleInput
    {
        public static int GetNumber(string caption)
        {
            Console.WriteLine(caption);
            var valueAsString = Console.ReadLine();
            var result = 0;
            
            while (true)
            {
                var parseSuccess = int.TryParse(valueAsString, out result);
                if (parseSuccess)
                    break;
                Console.WriteLine("This is not a number!");
                Console.WriteLine(caption);
                valueAsString = Console.ReadLine();
            }
            return result;
        }

        public static string GetControlledString(string keyword, Func<bool> predicate)
        {
            Console.WriteLine(keyword);
            var input = string.Empty;
            
            while (!predicate())
            {
                input = Console.ReadLine();
            }

            return input;
        }
    }
}