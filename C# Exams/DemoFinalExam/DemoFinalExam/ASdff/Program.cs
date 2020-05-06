using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Zadacha1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<asd>[#$%*&]+)(?<name>[a-zA-Z]+)\1=(?<length>[\d]+)!!(?<code>.+)$";

            // @"^([#$%*&])(?<name>[a-zA-Z]+)\1=(?<length>[\d]+)!!(?<code>.+)$" - veren Regex
            // @"^(?<smth>[#$%*&])(?<name>[a-zA-Z]+)(\1)=(?<length>[\d]+)!!(?<code>.+)$" - greshen Regex

            var racerName = string.Empty;
            var lengthOfCode = 0;
            var code = string.Empty;
            var decryptedMsg = new StringBuilder();
            while (true)
            {
                var input = Console.ReadLine();
                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    racerName = match.Groups["name"].ToString();
                    lengthOfCode = int.Parse((match.Groups["length"]).ToString());
                    code = match.Groups["code"].ToString();
                    if (code.Length == lengthOfCode)
                    {

                        foreach (var character in code)
                        {
                            char decryptedChar = character;
                            decryptedChar += (char)lengthOfCode;
                            decryptedMsg.Append(decryptedChar);

                        }
                        Console.WriteLine($"Coordinates found! {racerName} -> {decryptedMsg}");
                        break;
                    }
                    
                }
                else
                    Console.WriteLine("Nothing found!");
            }
        }
    }
}