﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Domain.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int ConcertId { get; set; }
        public Concert Concert { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
