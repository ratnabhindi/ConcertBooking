using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Domain.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public required int SeatNumber { get; set; }
        public required bool IsBooked { get; set; }
        //[ForeignKey("BookingId")]
        public int? BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
