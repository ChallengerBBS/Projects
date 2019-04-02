using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace _04_MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            var matches = Regex.Matches(input, @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))");
            
            Console.WriteLine(string.Join(" ", matches));

        }
    }
}
