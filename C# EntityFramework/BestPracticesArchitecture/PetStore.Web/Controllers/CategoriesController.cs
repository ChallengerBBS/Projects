namespace PetStore.Web.Controllers
    {

    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services;
    using PetStore.Web.Models.Categories;
    
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult All()
        {
            var categories = this.categoryService.All()
                .Select(csm => new CategoryListingViewModel
                {
                    Id=csm.Id,
                    Name=csm.Name
                })
                .ToArray();
            return View(categories);
        }
    }
}