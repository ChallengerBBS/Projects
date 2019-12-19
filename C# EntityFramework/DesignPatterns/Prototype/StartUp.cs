namespace Prototype
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["Hamburger"] = new Sandwich("Wheat", "Ham", "Swiss", "Lettuce");

            Sandwich sandwich1 = sandwichMenu["Hamburger"].Clone() as Sandwich;

        }
    }
}
