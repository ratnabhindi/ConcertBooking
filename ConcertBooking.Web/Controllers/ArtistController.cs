using ConcertBooking.Application.Services.Interfaces;
using ConcertBooking.Domain.Models;
using ConcertBooking.Web.Models.ViewModels.ArtistViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.Web.Controllers
{
    public class ArtistController : Controller
    {
     
        private IUtilityService _utilityService;
        private IArtistService _artistService;
        private string containerName = "ArtistImage";

        public ArtistController(IUtilityService utilityService, IArtistService artistService)
        {
            _utilityService = utilityService;
            _artistService = artistService;
        }

        public IActionResult Index()
        {
            List<ArtistViewModel> vm = new List<ArtistViewModel>();
            var artists = _artistService.GetAllArtist();

            foreach (var artist in artists)
            {
                vm.Add(new ArtistViewModel
                { Id = artist.Id, Name = artist.Name, Bio = artist.Bio, ImageUrl= artist.ImageUrl });
            }

            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArtistViewModel vm)
        {
            var artist = new Artist {Name = vm.Name, Bio = vm.Bio };
            _artistService.SaveArtist(artist);

            if(vm.ImageUrl != null)
            {
                artist.ImageUrl = await _utilityService.SaveImageAsync(containerName, vm.ImageUrl);
            }

            await _artistService.SaveArtist(artist);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var artist = _artistService.GetArtistById(id);
            var vm = new EditArtistViewModel { Id = artist.Id, Name=artist.Name, Bio=artist.Bio, ImageUrl=artist.ImageUrl };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditArtistViewModel vm)
        {
            var artist = _artistService.GetArtistById(vm.Id);
            artist.Name = vm.Name;
            artist.Bio = vm.Bio;
            if(vm.ImageUrl != null)
            {
                artist.ImageUrl = await _utilityService.EditImageAsync(containerName, vm.ChooseImage, artist.ImageUrl);
            }
            _artistService.UpdateArtist(artist);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var artist = _artistService.GetArtistById(id);
            await _utilityService.DeleteImage(containerName, artist.ImageUrl);
            _artistService.DeleteArtist(artist);
            return RedirectToAction("Index");

        }
    }
}
