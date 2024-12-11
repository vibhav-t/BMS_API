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
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Blog>> GetAll()
        {
            return await _mediator.Send(new GetAllBlogQuery());
        }
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBlogCommand { Id=id});
            return Ok();
        }
    }
}
