namespace MyFirstAspNetCoreApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class Names
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class TestInputModel
    {
        public int Id { get; set; }

        [Required]
        public Names Names { get; set; }

        [Required]
        [MinLength(3)]
        public string University { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(10,MinimumLength=10)]
        [RegularExpression("[0-9]{10}", ErrorMessage ="Invalid EGN !")]
        public string Egn { get; set; }

        public int[] Years { get; set; }

        public int Year { get; set; }
    }

    public class TestController : Controller
    {
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