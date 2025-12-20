using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutBreadCrumbComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}