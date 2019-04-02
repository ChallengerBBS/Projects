using System;


namespace Something
{
    class Something
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            string biggestKegModel = String.Empty;
            double biggestVolumeOfKeg = 0;

            for (int i = 0; i < numberOfKegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double singleKegVolume = Math.PI * radius * radius * height;
                if (singleKegVolume>biggestVolumeOfKeg)
                {
                    biggestVolumeOfKeg = singleKegVolume;
                    biggestKegModel = model;
                }

            }
            Console.WriteLine(biggestKegModel);
        }
    }
}
