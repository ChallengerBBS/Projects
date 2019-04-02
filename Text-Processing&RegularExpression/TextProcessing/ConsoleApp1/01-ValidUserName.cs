using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var usernames = Console.ReadLine().Split(", ").ToArray();
            bool isValid = false;

            for (int i = 0; i < usernames.Length; i++)
            {
                
                var currentUsername = usernames[i];
                if (currentUsername.Length >= 3 && currentUsername.Length <= 16)
                {

                    for (int j = 0; j < currentUsername.Length; j++)
                    {
                        char currentCharacter = currentUsername[j];
                        if (char.IsLetterOrDigit(currentCharacter) || 
                            currentCharacter == '-' || 
                            currentCharacter == '_')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                        Console.WriteLine(currentUsername);
                }
               
            }
            
        }
    }
}
