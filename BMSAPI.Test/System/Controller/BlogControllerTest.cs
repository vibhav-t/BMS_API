using BMSAPI.Controllers;
using BMSAPI.Entities.Model;
using BMSAPI.Helpers;
using BMSAPI.Repository.Commands.Command;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BMSAPI.Test.System.Controller
{
    public class BlogControllerTest
    {
        private readonly IMediator _mediator;
        private readonly BlogController _blogController;

        public BlogControllerTest()
        {
            //set up dependencies
            this._mediator = A.Fake<IMediator>();

            //system under test
            this._blogController = new BlogController(this._mediator);
        }
        private static Blog CreateFakeBlog() => A.Fake<Blog>();

        [Fact]
        public async Task BlogController_Create_ReturnSuccess()
        {
            //Arrange
            var command = new CreateBlogCommand
            {
                Username = "Test User",
                DateCreated = DateTime.Now,
                Text = "Test blog"
            };
            A.CallTo(() => _mediator.Send(command, A<CancellationToken>.Ignored)).Returns(Task.FromResult(1));

            // Act
            var result = await _blogController.Create(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal("Blog item added!!", apiResponse.Message);
        }
        [Fact]
        public async Task Create_ReturnsBadRequest_WhenBlogItemIsNotAdded()
        {
            // Arrange
            var command = new CreateBlogCommand {  };
            A.CallTo(() => _mediator.Send(command, A<CancellationToken>.Ignored)).Returns(Task.FromResult(0));

            // Act
            var result = await _blogController.Create(command);

            // Assert
            var badRequestResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Failed to add blog item", badRequestResult.Value);
        }
    }
}
