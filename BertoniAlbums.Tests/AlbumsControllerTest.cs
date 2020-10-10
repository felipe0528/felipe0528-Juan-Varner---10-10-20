using BertoniAlbums.Controllers;
using BertoniAlbums.DTOs;
using BertoniAlbums.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BertoniAlbums.Tests
{
    [TestClass]
    public class AlbumsControllerTest
    {
        [TestMethod]
        public async Task TestAlbumsListAsync()
        {
            List<AlbumDTO> testAlbums = new List<AlbumDTO>
            {
                new AlbumDTO()  { Id = 1, Title="TitleTest1" },
                new AlbumDTO()  { Id = 2, Title="TitleTest2" },
            };

            var mockService = new Mock<IAlbumService>();
            mockService.Setup(repo => repo.GetAllAlbums()).Returns(Task.FromResult(testAlbums));

            var mockPhotoService = new Mock<IPhotosService>();

            var controller = new AlbumsController(mockService.Object, mockPhotoService.Object);
            var result = await controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            CollectionAssert.AllItemsAreNotNull((ICollection)((ViewResult)result).Model);
        }
    }
}
