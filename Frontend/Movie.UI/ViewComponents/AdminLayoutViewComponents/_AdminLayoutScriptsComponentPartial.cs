using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}