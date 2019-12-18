using PetStore.Services.Models.Category;
using System.Collections.Generic;

namespace PetStore.Services
{
    public interface ICategoryService
    {
        bool Exists(int categoryId);

        IEnumerable<AllCategoriesServiceModel> All();
    }
}
