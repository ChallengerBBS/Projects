using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _10_CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsAsString = Console.ReadLine();
            var stringToRemove = Console.ReadLine();
            var words = wordsAsString.Split(", ");

            foreach (var word in words)
            {
                string newString = "";
                for (int i = 0; i < word.Length; i++)
                {
                    newString += "*";
                }
                stringToRemove = stringToRemove.Replace(stringToRemove, newString);
            }
            
            Console.WriteLine(words);
        }
    }
}
