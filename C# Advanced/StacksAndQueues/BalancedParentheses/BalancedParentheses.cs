namespace BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BalancedParentheses

    {
        static void Main(string[] args)
        {
            var stackOfParentheses = new Stack<char>();
            char[] input = Console.ReadLine().ToCharArray();
            char[] openParentheses = new char[] { '{', '[', '(' };
            bool isValid = true;
         
            foreach (var item in input)
            {
                if (openParentheses.Contains(item))
                {
                    stackOfParentheses.Push(item);
                    continue;
                    
                }
                if (stackOfParentheses.Count==0)
                {
                    isValid = false;
                    break;
                }
                if (stackOfParentheses.Peek() == '(' && item == ')')

                {
                    stackOfParentheses.Pop();
                }
                else if (stackOfParentheses.Peek() == '[' && item == ']')

                {
                    stackOfParentheses.Pop();
                }
                else if (stackOfParentheses.Peek() == '{' && item == '}')

                {
                    stackOfParentheses.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
                Console.WriteLine("NO");
        }
    }
}
