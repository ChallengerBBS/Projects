using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyFirstAspNetCoreApp.Filters;
using MyFirstAspNetCoreApp.Models;
using MyFirstAspNetCoreApp.Services;
using MyFirstAspNetCoreApp.ViewModels.Home;

namespace MyFirstAspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountInstancesService _countInstancesService;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public HomeController(
            ICountInstancesService countInstancesService,
            IConfiguration configuration,
            IWebHostEnvironment env
            )
        {
            _countInstancesService = countInstancesService;
            _configuration = configuration;
            _env = env;
            
        }

        public IActionResult HttpError(int statusCode)
        {
            return this.View(statusCode);
        }
        [MyAuthorizationFilter]
        [MyExceptionFilter]
        [MyResourceFilter]
        [MyResultFilter]
        
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Year = DateTime.UtcNow.Year,
                Message = "some message"
            };
            return View(viewModel);
        }

        [AddHeaderActionFilterAttribute]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return this.Content(_configuration["YouTube:ApiKey"]);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
