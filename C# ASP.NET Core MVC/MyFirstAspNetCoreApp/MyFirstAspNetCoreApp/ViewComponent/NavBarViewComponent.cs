namespace MyFirstAspNetCoreApp.ViewComponent
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstAspNetCoreApp.Services;
    using MyFirstAspNetCoreApp.ViewModels.NavBar;

    [ViewComponent(Name = "NavBar")]
    public class NavBarViewComponent : ViewComponent
    {
        private readonly IYearsService yearsService;

        public NavBarViewComponent(IYearsService yearsService)
        {
            this.yearsService = yearsService;
        }

        public IViewComponentResult Invoke(int count)
        {
            var viewModel =new NavBarViewModel();
            viewModel.Years = this.yearsService.GetLastYears(count);
            return this.View(viewModel);
        }


    }


}
