using BMSAPI.Entities.Model;
using BMSAPI.Repository.Commands.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BMSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /*[HttpGet] 
        public async Task<IEnumerable<Blog>> GetAll()
        {
            return await _mediator.Send(new GetAllBlogPostsQuery());
        }
        [HttpGet("{id}")] 
        public async Task<Blog> GetById(int id)
        {
            return await _mediator.Send(new GetBlogPostByIdQuery { Id = id });
        }*/
        [HttpPost]
        public async Task<int> Create(CreateBlogCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
        {
            if (id != command.Id) { return BadRequest(); }
            await _mediator.Send(command); return NoContent();
        }
    }
}
