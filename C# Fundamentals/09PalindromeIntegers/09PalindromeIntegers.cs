using System;

namespace _09PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            while (number != "END")
            {
                if(IsItPalindrome(number))
                    {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                number = Console.ReadLine();
            }
        }

        private static bool IsItPalindrome(string number)
        {
            string first = number.Substring(0, number.Length / 2);
            char[] arr = number.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            string second = temp.Substring(0, temp.Length / 2);

            return first.Equals(second);
        }
    }
}
