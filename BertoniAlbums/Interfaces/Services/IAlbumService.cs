using BertoniAlbums.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAlbums.Interfaces
{
    public interface IAlbumService
    {
        Task<List<AlbumDTO>> GetAllAlbums();
    }
}
