﻿using ConcertBooking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Application.Services.Implementations
{
    public class UtilityService : IUtilityService
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor _contentAccessor;

        public Task DeleteImage(string containerName, string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
            var filename = Path.GetFileName(dbPath);
            var completePath = Path.Combine(_env.WebRootPath, containerName, filename);

            if (!File.Exists(completePath)) { 
                File.Delete(completePath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string containerName, IFormFile file, string dbPath)
        {
            await DeleteImage(containerName, dbPath);
            return await SaveImage(containerName, file);
        }

        public async Task<string> SaveImage(string containerName, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, containerName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var filePath = Path.Combine(folder, filename);

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                await File.WriteAllBytesAsync(filePath, content);
            }
            var basePath = $"{_contentAccessor.HttpContext.Request.Scheme}://{_contentAccessor.HttpContext.Request.Host}";
            var combinedPath = Path.Combine(basePath, containerName, filename).Replace("\\", "/");
            return combinedPath;
        }
    }

}
