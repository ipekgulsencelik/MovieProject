using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutRegisterModalComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}