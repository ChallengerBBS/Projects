
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFirstAspNetCoreApp.Services
{
    public class PositionService : IPositionService
    {
        public IEnumerable<SelectListItem> GetAll()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value = "1", Text="Junior Dev"},
                new SelectListItem{Value = "2", Text="Regular Dev"},
                new SelectListItem{Value = "3", Text="Junior QA"}
            };
        }
    }
}
