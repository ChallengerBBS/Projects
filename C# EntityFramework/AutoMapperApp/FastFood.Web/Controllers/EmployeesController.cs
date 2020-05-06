namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;

    using Data;
    using ViewModels.Employees;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using FastFood.Models;

    public class EmployeesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public EmployeesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            var positions = this.context.Positions
                               .ProjectTo<RegisterEmployeeViewModel>(mapper.ConfigurationProvider)
                           .ToList();

            return View(positions);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var employee = mapper.Map<Employee>(model);
            var position = context.Positions.FirstOrDefault(x => x.Name == model.PositionName);
            employee.PositionId = position.Id;

            context.Employees.Add(employee);
            context.SaveChanges();

            return RedirectToAction("All", "Employees");
        }

        public IActionResult All()
        {
            var employees = this.context
                             .Employees
                             .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider)
                             .ToList();

            return View(employees);
        }
    }
}
