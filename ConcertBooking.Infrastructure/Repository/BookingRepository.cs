﻿using ConcertBooking.Application.Common;
using ConcertBooking.Domain.Models;
using ConcertBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Infrastructure.Repository
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
