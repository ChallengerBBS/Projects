namespace MyFirstAspNetCoreApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Names
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }

    public class TestInputModel
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
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Invalid EGN !")]
        [Display(Name = "EGN")]
        public string Egn { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name ="Years of experience")]
        public int YearsOfExperience { get; set; }
    }

    public class TestController : Controller
    {

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Index(TestInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            return Json(input);
        }

    }
}