namespace MyFirstAspNetCoreApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyFirstAspNetCoreApp.Services;
    using MyFirstAspNetCoreApp.ValidationAttributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Names
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
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
        [EgnValidation]
        [Display(Name = "EGN")]
        public string Egn { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name ="Years of experience")]
        [Range(1,100)]
        public int YearsOfExperience { get; set; }

        public int CandidateType { get; set; }

        public IEnumerable<SelectListItem> AllTypes { get; set; }
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
                AllTypes = positionService.GetAll()
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Index(TestInputModel input)
        {
            if (!ModelState.IsValid)
            {
                input.AllTypes = positionService.GetAll();
                return View(input);
            }
            return Json(input);
        }

    }
}