using ConcertBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Application.Services.Interfaces
{
    public interface IConcertService
    {
        IEnumerable<Concert> GetAllConcert();
        Concert GetConcertById(int id);
        Task SaveConcert(Concert Concert);
        Task DeleteConcert(Concert Concert);
        void UpdateConcert(Concert Concert);
    }
}
