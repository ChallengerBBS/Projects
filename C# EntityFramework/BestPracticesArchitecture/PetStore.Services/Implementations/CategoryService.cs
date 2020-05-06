namespace PetStore.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using PetStore.Services.Models.Category;

    public class CategoryService : ICategoryService
    {
        private readonly PetStoreDbContext data;
        public CategoryService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<AllCategoriesServiceModel> All()
        {
            return this.data.Categories.Select(c => new AllCategoriesServiceModel()
                                                {
                                                    Id = c.Id,
                                                    Name = c.Name,
                                                    Description = c.Description
                                                })
                                                .ToArray();
        }

        public bool Exists(int categoryId)
        {
            return this.data.Categories.Any(c => c.Id == categoryId);
        }
    }
}
