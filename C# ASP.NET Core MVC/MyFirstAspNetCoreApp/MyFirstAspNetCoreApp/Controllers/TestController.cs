namespace MyFirstAspNetCoreApp.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyFirstAspNetCoreApp.Services;
    using MyFirstAspNetCoreApp.ValidationAttributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class Names
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }

    public class TestInputModel : IValidatableObject
    {

        [Required]
        public Names Names { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "University")]
        public string University { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [EgnValidation]
        [Display(Name = "EGN")]
        public string Egn { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Years of experience")]
        [Range(1, 100)]
        public int YearsOfExperience { get; set; }

        public int CandidateType { get; set; }

        public IEnumerable<SelectListItem> AllTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (int.Parse(this.Egn.Substring(0, 2)) != this.DateOfBirth.Year % 100)
            {
                yield return new ValidationResult("Годината на раждане и ЕГН-то не са валидна комбинация");
            }
        }

        public IFormFile CV { get; set; }
    }

    public class TestController : Controller
    {
        private readonly IPositionService positionService;

        public TestController(IPositionService positionService)
        {
            this.positionService = positionService;
        }
        public IActionResult Index()
        {
            var model = new TestInputModel
            {
                University="Softuni",
                AllTypes = positionService.GetAll(),
                DateOfBirth= new DateTime(2012,1,1),
                Egn="1234567890",
                Email="asd@abv.bg",
                YearsOfExperience=2,


            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TestInputModel input)
        {
            if (!ModelState.IsValid)
            {
                input.AllTypes = positionService.GetAll();
                return View(input);
            }

            using (var fileStream = new FileStream(@"C:\Users\chall\OneDrive\Desktop\CV.pdf", FileMode.Create))
            {
              
                await input.CV.CopyToAsync(fileStream);
            }
            return Redirect("/");
        }
    }
}





