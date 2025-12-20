using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutSwitcherComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}