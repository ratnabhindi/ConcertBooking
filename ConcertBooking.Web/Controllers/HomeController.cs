using ConcertBooking.Application.Services.Interfaces;
using ConcertBooking.Domain.Models;
using ConcertBooking.Web.Models;
using ConcertBooking.Web.Models.ViewModels.DashboardViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConcertBooking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConcertService _concertService;
        private readonly  ITicketService _ticketService;
        private readonly IBookingService _bookingService;

        public HomeController(ILogger<HomeController> logger, IConcertService concertService, ITicketService ticketService, IBookingService bookingService)
        {
            _logger = logger;
            _concertService = concertService;
            _ticketService = ticketService;
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            DateTime today = DateTime.Today;
            var concerts =  _concertService.GetAllConcert();
            var vm = concerts.Where(d => d.DateTime >= today)
                .Select(x => new HomeConcertViewModel
                {
                    ConcertId = x.Id,
                    ConcertName = x.Name,
                    ArtistName = x.Artist.Name,
                    ConcertImage = x.ImageUrl,
                    Description = x.Description.Length > 100 ? x.Description.Substring(1, 100) : x.Description
                }).ToList();

            return View(vm);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var concert = _concertService.GetConcertById(id);
            if (concert == null)
            {
                return NotFound();
            }
            var vm = new HomeConcertDetailsViewModel
            {           
                ConcertId = concert.Id,
                ConcertName = concert.Name,
                ConcertImage = concert.ImageUrl,
                Description = concert.Description,
                ConcertDateTime = concert.DateTime,
                ArtistName = concert.Artist.Name,
                ArtistImage = concert.Artist.ImageUrl,           
                VenueAddress = concert.Venue.Address,
                VenueName = concert.Venue.Name         

            };

            return View(vm);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
