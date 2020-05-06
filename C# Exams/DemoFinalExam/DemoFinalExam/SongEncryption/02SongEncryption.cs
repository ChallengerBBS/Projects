using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string bandsAndSongs = "";
            string artistPattern = @"^(?<artist>[A-Z][a-z ']*)$";
            string songPattern = @"^(?<song>[A-Z ]+)$";
            string keepPattern = @"[^' @]";
            var sb = new StringBuilder();
            while ((bandsAndSongs=Console.ReadLine())!="end")
            {
                var cmdLine = bandsAndSongs.Split(":");
                var artist = cmdLine[0];
                var song = cmdLine[1];
                bool isArtistValid = Regex.IsMatch(artist, artistPattern);
                bool isSongValid = Regex.IsMatch(song, songPattern);
                if (!isArtistValid || !isSongValid)
                    Console.WriteLine("Invalid input!");
                else if (isArtistValid && isSongValid)
                {
                    sb = sb.Clear();
                    var artistMatch = Regex.Match(artist, artistPattern);
                    var songMatch = Regex.Match(song, songPattern);
                    int lenght = artist.Length;
                    string text = $"{artistMatch}@{songMatch}";

                    foreach (char character in text)
                    {
                        char newChar = character;
                        
                        bool isValidCharacter = Regex.IsMatch(newChar.ToString(), keepPattern);
                        if (isValidCharacter)
                        {
                            newChar += (char)lenght;
                            if (character<=90 && newChar>90)
                            {
                                newChar -= (char)26;
                                
                            }
                            else if (character <= 122 && newChar > 122)
                            {
                                newChar -= (char)26;
                                
                            }
                        }
                        sb.Append(newChar);
                    }
                    Console.WriteLine($"Successful encryption: {sb}");
                }
            }
        }
    }
}
