namespace PetStore.Services
{
using System;
    using System.Collections.Generic;
    using Data.Models;
    using Services.Models.Pet;

    public interface IPetService
    {
        PetDetailsServiceModel Details(int id);

        IEnumerable<PetListingServiceModel> All(int page = 1);
        void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId);

        void SellPetToUser(int petId, int userId);

        bool Exists(int petId);

        int Total();
        bool Delete(int id);

    }
}
