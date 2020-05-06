using Wildfarm.Models.Foods.Interfaces;

namespace Wildfarm.Models.Foods.Entities
{
     public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
