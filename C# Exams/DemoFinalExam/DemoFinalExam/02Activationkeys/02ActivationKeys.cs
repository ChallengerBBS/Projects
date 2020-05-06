using System;
using System.Collections.Generic;

namespace _02Activationkeys
{
    class Program
    {
        static void Main(string[] args)
        {
            var keys = Console.ReadLine().Split("&");
            var validKeys = new List<string>();
            foreach (var key in keys)
            {
                if (key.Length == 16 || key.Length == 25)
                {
                    bool isValid = true;
                    foreach (var symbol in key)
                    {
                        if (!char.IsLetterOrDigit(symbol))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        validKeys.Add(key.ToUpper());
                    }
                }
                
            }
            for (int i = 0; i < validKeys.Count; i++)
            {
                if (validKeys[i].Length==16)
                {
                    validKeys[i] = validKeys[i].Insert(4, "-");
                    validKeys[i] = validKeys[i].Insert(9, "-");
                    validKeys[i] = validKeys[i].Insert(14, "-");
                }
                else if (validKeys[i].Length == 25)
                {
                    validKeys[i] = validKeys[i].Insert(5, "-");
                    validKeys[i] = validKeys[i].Insert(11, "-");
                    validKeys[i] = validKeys[i].Insert(17, "-");
                    validKeys[i] = validKeys[i].Insert(23, "-");
                }
            }
            for (int i = 0; i < validKeys.Count; i++)
            {
                for (int j = 0; j < validKeys[i].Length; j++)
                {
                    if(char.IsDigit(validKeys[i][j]))
                    {
                        int currentDigit = 9 - int.Parse(validKeys[i][j].ToString());
                        validKeys[i] = validKeys[i].Remove(j, 1);
                        validKeys[i]=validKeys[i].Insert(j, currentDigit.ToString());
                    }
                }
            }
            if(validKeys.Count>0)
            {
                Console.WriteLine(string.Join(", ", validKeys));
            }
        }
    }
}
