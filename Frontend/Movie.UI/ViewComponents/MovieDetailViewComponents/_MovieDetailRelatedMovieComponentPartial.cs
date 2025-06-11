using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailRelatedMovieComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}