using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutPreloaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}