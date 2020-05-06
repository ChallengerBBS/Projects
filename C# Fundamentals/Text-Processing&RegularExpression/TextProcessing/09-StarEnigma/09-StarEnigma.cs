using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace _09_StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int countMsg = int.Parse(Console.ReadLine());
            var printResult = new StringBuilder();
            for (int i = 0; i < countMsg; i++)
            {
                int charCount = 0;
                var encryptedMsg = Console.ReadLine();
                for (int j = 0; j < encryptedMsg.Length; j++)
                {
                    if (char.ToLower(encryptedMsg[j])=='s'||
                        char.ToLower(encryptedMsg[j]) == 't' ||
                        char.ToLower(encryptedMsg[j]) == 'a' ||
                        char.ToLower(encryptedMsg[j]) == 'r'  )
                    {
                        charCount++;
                    }
                }
                for (int j = 0; j < encryptedMsg.Length; j++)
                {
                    printResult.Append((char)(encryptedMsg[j] - charCount));
                }

            }
            Console.WriteLine(printResult);
        }
    }
}
