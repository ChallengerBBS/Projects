using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyFirstAspNetCoreApp.ModelBinders
{
    public class YearModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
