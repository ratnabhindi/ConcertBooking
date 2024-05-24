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
    public class VenueRepository : GenericRepository<Venue>, IVenueRepository
    {
        private readonly ApplicationDBContext _context;
        public VenueRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public void UpdateVenue(Venue venue)
        {
          _context.Venues.Update(venue);
        }
    }
}
