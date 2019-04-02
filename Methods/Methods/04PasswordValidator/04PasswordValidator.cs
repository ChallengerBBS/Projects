using System;

namespace _04PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isSixToTenCharacters = CharacterCountValidator(password);
            bool containsLettersAndDigits = LettersAndCharactersValidator(password);
            bool hasAtleastTwoDigits = AtleastTwoDigitsValidator(password);

            if (isSixToTenCharacters==false)
                Console.WriteLine("Password must be between 6 and 10 characters");
            if (containsLettersAndDigits==false)
                Console.WriteLine("Password must consist only of letters and digits");
            if (hasAtleastTwoDigits==false)
                Console.WriteLine("Password must have at least 2 digits");

            if (isSixToTenCharacters&& containsLettersAndDigits&& hasAtleastTwoDigits)
                Console.WriteLine("Password is valid");

        }

        private static bool AtleastTwoDigitsValidator(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if(char.IsDigit(password[i]))
                {
                    count++;
                }
            }
            if (count>=2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool LettersAndCharactersValidator(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    return false;
                }
     
            }
            return true;

        }

        private static bool CharacterCountValidator(string password)
        {
            if (password.Length>=6&&password.Length<=10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
