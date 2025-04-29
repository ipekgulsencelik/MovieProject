using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailShareSocialMediaComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}