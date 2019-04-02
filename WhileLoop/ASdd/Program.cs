using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            double mFood = double.Parse(Console.ReadLine());
            double mSouvenirs = double.Parse(Console.ReadLine());
            double mHotel = double.Parse(Console.ReadLine());
            double mFuel = (420.0 / 100 * 7)*1.85;
            
            double mTrip = 3 * mFood + 3 * mSouvenirs;
            double mHotelTotal = (mHotel * 0.9) + (mHotel * 0.85) + (mHotel * 0.8);
            double total = mFuel + mTrip + mHotelTotal;
            Console.WriteLine($"Money needed: {total:f2}");
        


        
        }

        }
    }

