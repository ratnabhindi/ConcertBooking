﻿using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.Web.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
