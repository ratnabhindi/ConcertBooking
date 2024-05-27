namespace ConcertBooking.Web.Models.ViewModels.ArtistViewModels
{
    public class ArtistViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Bio { get; set; }
        public string? ImageUrl { get; set; }
    }
}
