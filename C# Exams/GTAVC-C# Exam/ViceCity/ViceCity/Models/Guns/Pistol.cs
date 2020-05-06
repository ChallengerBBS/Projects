namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int defaultBulletsPerBarrel = 10;
        private const int defaultTotalBullets = 100;
        public Pistol(string name)
            : base(name, defaultBulletsPerBarrel, defaultTotalBullets)
        {
        }

        public override int Fire()
        {
            int defaultFiringCount = 1;

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
