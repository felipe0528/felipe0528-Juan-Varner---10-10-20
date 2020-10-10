using BertoniAlbums.DTOs;
using BertoniAlbums.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAlbums.Services
{
    public class CommentsService : ICommentsService
    {
        private IAlbumsInterface _albumsInterface;

        public CommentsService(IAlbumsInterface albumsInterface)
        {
            _albumsInterface = albumsInterface;
        }

        public async Task<List<CommentDTO>> GetCommentsByPhotoId(int photoId)
        {
            var response = await _albumsInterface.GetCommentsByPhotoId(photoId);
            var comments = response.Select(x => new CommentDTO
            {
                Id = x.Id,
                Name = x.Name,
                Body = x.Body
            }).ToList();

            return comments;
        }
    }
}
