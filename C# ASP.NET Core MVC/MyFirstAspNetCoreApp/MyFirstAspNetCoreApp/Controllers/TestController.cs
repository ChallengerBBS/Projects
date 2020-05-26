namespace MyFirstAspNetCoreApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstAspNetCoreApp.ModelBinders;
    using System.ComponentModel.DataAnnotations;

    public class TestInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int[] Years { get; set; }

        [ModelBinder(typeof(YearModelBinder))]
        public int Year { get; set; }
    }

    public class TestController : Controller
    {
        public IActionResult Index(TestInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return Content("Invalid model");
            }
            return Json(input);
        }
    }
}