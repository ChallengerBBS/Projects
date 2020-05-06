using System;

namespace _7._5Travelling
{
    class Travelling
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            //bool flag = true;

            while (destination != "End")
            {
                int diudet = int.Parse(Console.ReadLine());
                int sum = 0;
                while (diudet > sum)
                {
                    //string vlog = Console.ReadLine();
                    //if (vlog=="End")
                    //{
                    //    flag = false;
                    //    break;
                    //}
                    int spesteni = int.Parse(Console.ReadLine());
                    sum += spesteni;


                }
                Console.WriteLine($"Going to {destination}!");
                //if (flag==false)
                //{
                //    break;
                //}
                destination = Console.ReadLine();

            }


        }
    }
}