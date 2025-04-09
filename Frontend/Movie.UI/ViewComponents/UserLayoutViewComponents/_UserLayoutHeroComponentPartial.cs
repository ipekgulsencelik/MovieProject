using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutHeroComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}