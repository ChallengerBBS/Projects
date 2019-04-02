using System;

namespace _02VoyelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(VowelsCount(input)); 
        }

        private static int VowelsCount(string input)
        {
            int vowelsCount = 0;
            string inputToLower = input.ToLower();
            for (int i = 0; i < inputToLower.Length; i++)
            {
                if (inputToLower[i]=='a'||
                    inputToLower[i] == 'y'||
                    inputToLower[i] == 'o'||
                    inputToLower[i] == 'u'||
                    inputToLower[i] == 'e'||
                    inputToLower[i] == 'i')
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }
    }
}
