using BertoniAlbums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAlbums.Interfaces
{
    public interface IAlbumsRepository
    {
        Task<List<Album>> GetAllAlbums();
        Task<List<Photo>> GetPhotosByAlbumId(int albumId);
        Task<Photo> GetPhotoById(int photoId);
        Task<List<Comment>> GetCommentsByPhotoId(int photoId);
    }
}
