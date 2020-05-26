using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MyFirstAspNetCoreApp.Filters
{
    public class AddHeaderActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Info", "hello!");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

    }
}
