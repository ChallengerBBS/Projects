using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int defaultBulletsPerBarrel = 50;
        private const int defaultTotalBullets = 500;

        public Rifle(string name)
            : base(name, defaultBulletsPerBarrel, defaultTotalBullets)
        {
        }

        public override int Fire()
        {
            int defaultFiringCount = 5;

            if (BulletsPerBarrel == 0)
            {
                return 0;
            }
            else
            {
                BulletsPerBarrel -= defaultFiringCount;

                if (BulletsPerBarrel == 0)
                {
                    if (TotalBullets > 0)
                    {
                        BulletsPerBarrel += barrelCapacity;
                        TotalBullets -= barrelCapacity;
                    }
                }

                return defaultFiringCount;
            }
        }
    }
}