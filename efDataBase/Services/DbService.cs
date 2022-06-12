using efDataBase.Models;
using efDataBase.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efDataBase.Services
{
    public class DbService : IDbService
    {
        private readonly s19754Context _context;

        public DbService(s19754Context context)
        {
            _context = context;
        }

        public async Task<bool> DoesAlbumExist(int idAlbum)
        {
            var klient = await _context.Albums.Where(e => e.IdAlbum == idAlbum).FirstOrDefaultAsync();
            if (klient is null) return false;
            return true;
        }

        

        public async Task<IEnumerable<SomeSortOfAlbum>> GetAlbum(int idAlbum)
        {
            return await _context.Albums.Where(e => e.IdAlbum == idAlbum)
                .Select(e => new SomeSortOfAlbum
                {
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate
                }).ToListAsync();


        }
        

    }
}
