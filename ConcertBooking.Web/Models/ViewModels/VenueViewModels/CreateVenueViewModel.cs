namespace ConcertBooking.Web.Models.ViewModels.VenueViewModels
{
    public class CreateVenueViewModel
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required int SeatCapacity { get; set; }
    }
}
