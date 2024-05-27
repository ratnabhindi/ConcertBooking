using ConcertBooking.Application.Services.Interfaces;
using ConcertBooking.Domain.Models;
using ConcertBooking.Web.Models.ViewModels.ConcertViewModels;
using ConcertBooking.Web.Models.ViewModels.DashboardViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConcertBooking.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConcertsController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IBookingService _bookingService;
        private readonly IConcertService _concertService;
        private readonly IUtilityService _utilityService;
        private readonly IVenueService _venueService;
        private string containerName = "ConcertImage";

        public ConcertsController(IArtistService artistService, 
            IBookingService bookingService, 
            IConcertService concertService, 
            IUtilityService utilityService, 
            IVenueService venueService)
        {
            _artistService = artistService;
            _bookingService = bookingService;
            _concertService = concertService;
            _utilityService = utilityService;
            _venueService = venueService;         
        }

        public IActionResult Index()
        {
            var concerts = _concertService.GetAllConcert();
            List<ConcertViewModel> vm = new List<ConcertViewModel>();
            foreach (var concert in concerts)
            {
                vm.Add(new ConcertViewModel
                {
                    Id = concert.Id,
                    Name = concert.Name,
                    ArtistName = concert.Artist.Name,
                    VenueName = concert.Venue.Name,
                    DateTime = concert.DateTime,
                });
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        { 
            var venues = _venueService.GetAllVenue();
            var artists = _artistService.GetAllArtist();
            ViewBag.VenueList = new SelectList(venues, "Id", "Name");
            ViewBag.ArtistList = new SelectList(artists, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateConcertViewModel vm)
        {
            var concert = new Concert
            {
                Name = vm.Name,
                ArtistId = vm.ArtistId,
                Description = vm.Description,
                VenueId = vm.VenueId,
                DateTime = vm.DateTime

            };

            if (vm.ImageUrl != null)
            {
                concert.ImageUrl = await _utilityService.SaveImageAsync(containerName, vm.ImageUrl);
            }
            await _concertService.SaveConcert(concert);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var concert = _concertService.GetConcertById(id);
            var artists = _artistService.GetAllArtist();
            var venues = _venueService.GetAllVenue();

            ViewBag.ArtistList = new SelectList(artists, "Id", "Name");
            ViewBag.VenueList = new SelectList(venues, "Id", "Name");

            var vm = new EditConcertViewModel
            {
                Id = concert.Id,
                Name = concert.Name,
                ImageUrl = concert.ImageUrl,
                ArtistId = concert.ArtistId,
                VenueId = concert.VenueId,
                Description = concert.Description,
                DateTime = concert.DateTime
            };

            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditConcertViewModel vm)
        {
            var concert = _concertService.GetConcertById(vm.Id);
            concert.Id = vm.Id;
            concert.Name = vm.Name;
            concert.Description = vm.Description;
            concert.ArtistId = vm.ArtistId;
            concert.VenueId = vm.VenueId;
            concert.DateTime = vm.DateTime;
            if (vm.ImageUrl != null) {
                concert.ImageUrl = await _utilityService.EditImageAsync(containerName, vm.ChooseImage, concert.ImageUrl);
            }

            _concertService.UpdateConcert(concert);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var concert = _concertService.GetConcertById(id);
            if (concert != null)
            {
                await _utilityService.DeleteImage(containerName, concert.ImageUrl);
                await _concertService.DeleteConcert(concert);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> GetTickets(int id)
        {
            var bookings = _bookingService.GetAllBooking(id);
            var vm = bookings.Select(b => new DashboardViewModel
            {
                UserName = b.ApplicationUser.UserName,
                ConcertName = b.Concert.Name,
                SeatNumber = string.Join(",", b.Tickets.Select(t => t.SeatNumber))

            }).ToList();

            return View(vm);
        }
    }
}
