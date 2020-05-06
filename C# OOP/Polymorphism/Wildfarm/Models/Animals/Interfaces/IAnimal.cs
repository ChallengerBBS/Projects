using Wildfarm.Models.Foods.Interfaces;

namespace Wildfarm.Models.Animals.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string AskFood();

        void Feed(IFood food);
    }
}
