using ConcertBooking.Application.Common;
using ConcertBooking.Domain.Models;
using ConcertBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Infrastructure.Repository
{
    public class ConcertRepository : GenericRepository<Concert>, IConcertRepository
    {
        private readonly ApplicationDBContext _context;
        public ConcertRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public void UpdateConcert(Concert concert)
        {
            _context.Concerts.Update(concert);
        }
    }
}
