using System;

namespace MoreEx01_inputDataType
{
    
        class Program
        {
            static void Main(string[] args)
            {

                while (true)
                {
                    string word = Console.ReadLine();
                    if (word == "END")
                    {
                        break;
                    }
                    bool isBolean = bool.TryParse(word, out bool boolean);
                    bool isInteger = int.TryParse(word, out int integer);
                    bool isChar = char.TryParse(word, out char character);
                    bool isDouble = double.TryParse(word, out double floating);
                    if (isBolean)
                    {
                        Console.WriteLine($"{word} is boolean type");

                    }
                    else if (isInteger)
                    {
                        Console.WriteLine($"{word} is integer type");

                    }
                    else if (isChar)
                    {
                        Console.WriteLine($"{word} is character type");

                    }
                    else if (isDouble)
                    {
                        Console.WriteLine($"{word} is floating point type");

                    }
                    else
                    {
                        Console.WriteLine($"{word} is string type");
                    }
                }
            }
        }
    }