using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Application.Services.Interfaces
{
    public interface IUtilityService
    {
        Task<string> SaveImageAsync(string containerName, IFormFile file);
        Task<string> EditImageAsync(string containerName, IFormFile file, string dbPath);
        Task DeleteImage(string containerName, string dbPath);

    }
}
