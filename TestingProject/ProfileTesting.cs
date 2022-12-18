using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestingProject
{
    public class ProfileTesting
    {

        [Fact]
        public async Task deleteProfileAsync_ValidId_ReturnOkResultAsync()
        {
            var databaseMock = new Database();
            var controller = new ProfileController(database : databaseMock);
            var idp = "ae5793e3-574a-4e1c-82e0-d0a8b02c0ff2";
            var result = await controller.deleteProfileAsync(idp);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async Task deleteProfileAsync_InValidId_ReturnBadRequest()
        {
            var databaseMock = new Database();
            var controller = new ProfileController(database : databaseMock);
            var idp = "ae5793e32e0-d0a8b02c0ff2";
            var result = await controller.deleteProfileAsync(idp);
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public async Task deleteProfileAsync_ValidId_ReturnNotFound()
        {
            var databaseMock = new Database();
            var controller = new ProfileController(database : databaseMock);
            var idp = "ae7794e3-574a-4e1c-82e0-d0a8b02c0tf5";
            var result = await controller.deleteProfileAsync(idp);
            Assert.IsType<NotFoundResult>(result);

        }
    
    }
}