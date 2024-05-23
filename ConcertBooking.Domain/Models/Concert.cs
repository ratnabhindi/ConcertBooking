using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Domain.Models
{
    public class Concert
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public required DateTime DateTime { get; set; }
        [ForeignKey("VenueId")]
        public required int VenueId { get; set; } //default convention, VenueId (foreign key)
        public Venue Venue { get; set; }

        [ForeignKey("ArtistId")]
        public required int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
