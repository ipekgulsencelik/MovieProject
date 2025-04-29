using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailRateComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}