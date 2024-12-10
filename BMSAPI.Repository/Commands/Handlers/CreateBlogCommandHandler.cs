using BMSAPI.Entities.Model;
using BMSAPI.Repository.Commands.Command;
using BMSAPI.Repository.interfaces;
using MediatR;

namespace BMSAPI.Repository.Commands.Handlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBlogCommandHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var post = new Blog { Username = request.Username, DateCreated = request.Date, Text = request.Text };
            _unitOfWork.blogRepository.Add(post);
            await _unitOfWork.SaveAsync();
            return post.Id;
        }
    }
}
