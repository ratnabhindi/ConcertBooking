﻿using ConcertBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Application.Services.Interfaces
{
    public interface IVenueService
    {
        IEnumerable<Venue>GetAllVenue();
        Venue GetVenueById(int id);
        Task SaveVenue(Venue venue);
        Task DeleteVenue(Venue venue);
        void UpdateVenue(Venue venue);
    }
}
