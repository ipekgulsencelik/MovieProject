﻿using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}