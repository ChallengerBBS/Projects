namespace PetStore.Web.Controllers

{
  
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Models.Pets;

    public class PetsController : Controller
    {
        private readonly IPetService pets;

        public PetsController(IPetService pets)
            => this.pets = pets;

        public IActionResult All(int page = 1)
        {
            var pets = this.pets.All(page);
            var totalPets = this.pets.Total();

            var model = new AllPetsViewModel
            {
                Pets = pets,
                Total = totalPets,
                CurrentPage = page
            };

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var pet = pets.Details(id);

            if (pet==null)
            {
                return NotFound();
            }

            return View(pet);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var deleted =this.pets.Delete(id);
            if(!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
