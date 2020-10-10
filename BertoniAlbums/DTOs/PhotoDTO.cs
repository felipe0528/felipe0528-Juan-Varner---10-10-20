using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAlbums.DTOs
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
