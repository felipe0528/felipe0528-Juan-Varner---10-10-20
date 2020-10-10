using BertoniAlbums.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAlbums.Interfaces
{
    public interface IPhotosService
    {
        Task<List<PhotoDTO>> GetPhotosByAlbumId(int albumId);
        Task<PhotoDTO> GetPhotoById(int photoId);
    }
}
