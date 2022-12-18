using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace TestingProject
{
    public class ProductTesting
    {
        [Fact]
        public async Task GetProductByIdAsync_WrongGuidFormat_returnBadRequestAsync()
        {
            var databaseMock = new Database();
            var controller = new ProductController(database : databaseMock);
            var idp = "5180e24f8195da91c3ffb942a5dc";
            var result = await controller.getPRoductByIdAsync(id : idp) as RequestController;
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public async Task GetProductByIdAsync_CorrectFormatButNotinTheList_returnNotFound()
        {
            var databaseMock = new Database();
            var controller = new ProductController(database : databaseMock);
            var idp = "5170r24f-8195-47fd-a91c-3ffb9492a5dc";
            var result = await controller.getPRoductByIdAsync(id : idp);
            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public async Task GetProductByIdAsync_ProvideValidId_returnProduct()
        {
            var databaseMock = new Database();
            var controller = new ProductController(database : databaseMock);
            var idp = "5180e24f-8195-47fd-a91c-3ffb9462a5dc";
            var result = await controller.getPRoductByIdAsync(id : idp);
            Assert.IsType<OkResult>(result);
        }


        
    }
}