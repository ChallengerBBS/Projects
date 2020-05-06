using System;

using ClassBoxData.Models;

namespace ClassBoxData
{
    public class StartUp

    {
        public static void Main(string[] args)
        {
            try
            {
                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                var box = new Box(length, width, height);
                Console.WriteLine(box.ToString());

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);

            }
            
        }
                               
    }
}
