using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutLoginModalComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}