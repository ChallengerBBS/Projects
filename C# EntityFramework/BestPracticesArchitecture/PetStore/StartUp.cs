namespace PetStore
{

    using System;
    using System.Linq;

    using Data;
    using Data.Models;
    using Services.Implementations;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            //var brandService = new BrandService(data);

            //var brandWithToys = brandService.FindByIdWithToys(1);

            using (var data = new PetStoreDbContext())
            {
                //var userService = new UserService(data);
                //var breedService = new BreedService(data);
                var categoryService = new CategoryService(data);
                //var petService = new PetService(data, breedService, categoryService, userService);

                // petService.BuyPet(Data.Models.Gender.Male, DateTime.Now, 15, "Little puffy", 1, 1);

              

            }




        }
    }
}
