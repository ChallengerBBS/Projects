using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MyFirstAspNetCoreApp.Filters
{
    public class MyExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
        }
    }
}
