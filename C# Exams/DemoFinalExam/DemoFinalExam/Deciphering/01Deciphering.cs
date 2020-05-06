using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            var encodedBookMsg = Console.ReadLine();
            var subString = Console.ReadLine().Split(" ");
            var pattern = new Regex(@"(?>^)[d-z{},|#]+(?>$)");
            var displayMsg = new StringBuilder();

            if (!pattern.IsMatch(encodedBookMsg))
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }
            for (int i = 0; i < encodedBookMsg.Length; i++)
            {
                char symbol = encodedBookMsg[i];
                symbol -= (char)3;
                displayMsg.Append(symbol);

            }
            displayMsg.Replace(subString[0], subString[1]);
            Console.WriteLine(displayMsg);
        }
    }
}
