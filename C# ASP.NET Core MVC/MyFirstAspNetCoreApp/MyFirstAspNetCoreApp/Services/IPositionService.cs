
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFirstAspNetCoreApp.Services
{
    public interface IPositionService
    {
        IEnumerable<SelectListItem> GetAll();
    }
}
