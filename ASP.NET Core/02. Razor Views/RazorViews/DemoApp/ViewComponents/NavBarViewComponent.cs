using DemoApp.Services;
using DemoApp.ViewModels.NavBar;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.ViewComponents
{
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
            var viewModel = new NavBarViewModel();
            viewModel.Years = this.yearsService.GetLastYears(count);
            return View(viewModel);
        }
    }
}
