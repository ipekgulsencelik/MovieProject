using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailOverviewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}