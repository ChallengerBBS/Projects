using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace _05_ReplaceChar
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new StringBuilder(Console.ReadLine());
            var result = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {

                string currentChar = input[i].ToString();
                if (i > 0)
                {
                    string oldChar = input[i - 1].ToString();
                    if (currentChar != oldChar)
                    {
                        result.Add(oldChar);
                    }
                    if (i == input.Length - 1)
                    {
                        result.Add(currentChar);
                    }
                }

            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
