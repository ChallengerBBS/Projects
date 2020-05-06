namespace PetStore.Services
{
    using System.Collections.Generic;
    using Models.Brand;
    using Data.Models;

    public interface IBrandService
    {
        int Create(string name);

        IEnumerable<BrandListingServiceModel> SearchByName(string name);

        BrandWithToysServiceModel FindByIdWithToys(int id);


    }
}
