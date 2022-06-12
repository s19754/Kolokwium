using efDataBase.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efDataBase.Services
{
    public interface IDbService
    {
        Task<bool> DoesAlbumExist(int idAlbum);
        Task<IEnumerable<SomeSortOfAlbum>> GetAlbum(int idAlbum);
        

    }
}
