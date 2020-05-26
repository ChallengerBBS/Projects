using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyFirstAspNetCoreApp.ModelBinders
{
    public class YearModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
           if (context.BindingInfo.BinderModelName.ToLower()=="year"
                && context.BindingInfo.BinderType == typeof(int))
            {
                return new YearModelBinder();
            }

            return null;
        }
    }
}
