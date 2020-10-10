using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BertoniAlbums.Models;
using BertoniAlbums.Interfaces;

namespace BertoniAlbums.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumsService;
        private readonly IPhotosService _photosService;

        public AlbumsController(
            IAlbumService albumsService, IPhotosService photosService)
        {
            _albumsService = albumsService;
            _photosService = photosService;
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _albumsService.GetAllAlbums();

            return View(albums);
        }

        public async Task<IActionResult> Photos(int Id)
        {
            var photos = await _photosService.GetPhotosByAlbumId(Id);

            return View(photos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
