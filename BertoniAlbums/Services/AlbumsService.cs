using BertoniAlbums.DTOs;
using BertoniAlbums.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAlbums.Services
{
    public class AlbumsService : IAlbumService
    {
        private IAlbumsInterface _albumsInterface;

        public AlbumsService(IAlbumsInterface albumsInterface)
        {
            _albumsInterface = albumsInterface;
        }

        public async Task<List<AlbumDTO>> GetAllAlbums()
        {
            var response = await _albumsInterface.GetAllAlbums();
            var albums = response.Select(x => new AlbumDTO
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();

            return albums;
        }
    }
}
