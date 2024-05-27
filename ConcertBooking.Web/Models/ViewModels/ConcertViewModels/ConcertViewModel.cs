namespace ConcertBooking.Web.Models.ViewModels.ConcertViewModels
{
    public class ConcertViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string VenueName { get; set; }
        public string ArtistName { get; set; }
    }
}
