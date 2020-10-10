using BertoniAlbums.DTOs;
using BertoniAlbums.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAlbums.Services
{
    public class PhotosService : IPhotosService
    {
        private IAlbumsRepository _albumsInterface;
        private ICommentsService _commentsService;

        public PhotosService(IAlbumsRepository albumsInterface,
            ICommentsService commentsService)
        {
            _commentsService = commentsService;
            _albumsInterface = albumsInterface;
        }

        public async Task<List<PhotoDTO>> GetPhotosByAlbumId(int albumId)
        {
            var response = await _albumsInterface.GetPhotosByAlbumId(albumId);
            var photos = response.Select(x => new PhotoDTO
            {
                Id = x.Id,
                ThumbnailUrl = x.ThumbnailUrl,
                Title = x.Title,
                Comments = x.Comments.Select(y => new CommentDTO
                {
                    Id = y.Id,
                    Body = y.Body,
                    Name = y.Name
                }).ToList()
            }).ToList();

            return photos;
        }

        public async Task<PhotoDTO> GetPhotoById(int photoId)
        {
            var response = await _albumsInterface.GetPhotoById(photoId);
            var comments = await _commentsService.GetCommentsByPhotoId(photoId);

            PhotoDTO photo = new PhotoDTO()
            {
                Id = response.Id,
                Title = response.Title,
                Url = response.Url,
                Comments = comments ?? comments
            };

            return photo;
        }
    }
}
