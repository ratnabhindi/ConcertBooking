﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Domain.Models
{
    public class ApplicationUser
    {
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
