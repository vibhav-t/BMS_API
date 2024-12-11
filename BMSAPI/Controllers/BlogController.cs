using BMSAPI.Entities.Model;
using BMSAPI.Repository.Commands.Command;
using BMSAPI.Repository.Queries.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BMSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        #region variables
        private readonly IMediator _mediator;
        #endregion
        #region constructor
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        #region api-endpoints

        /// <summary>
        /// This is used to fetch list of all blog
        /// </summary>
        /// <returns>list of blog</returns>
        [HttpGet]
        public async Task<IEnumerable<Blog>> GetAll()
        {
            return await _mediator.Send(new GetAllBlogQuery());
        }

        /// <summary>
        /// This is used to get blog by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Blog</returns>
        [HttpGet("{id}")]
        public async Task<Blog> GetById(int id)
        {
            return await _mediator.Send(new GetBlogByIDQuery { Id = id });
        }
        [HttpPost]
        public async Task<int> Create(CreateBlogCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Used to update the blog by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
        {
            if (id != command.Id) 
            {
                return BadRequest();
            }
            var response=await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Used to delete blog by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBlogCommand(id));
            return Ok();
        }
        #endregion
    }
}
