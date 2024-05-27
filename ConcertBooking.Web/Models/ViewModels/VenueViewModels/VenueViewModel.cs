﻿namespace ConcertBooking.Web.Models.ViewModels.VenueViewModels
{
    public class VenueViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required int SeatCapacity { get; set; }
    }
}
