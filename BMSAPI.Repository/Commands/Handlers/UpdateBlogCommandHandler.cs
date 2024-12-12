using BMSAPI.Entities.Model;
using BMSAPI.Repository.Commands.Command;
using BMSAPI.Repository.interfaces;
using MediatR;

namespace BMSAPI.Entities.Commands.Handlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand,int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBlogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.blogRepository.GetByIdAsync(request.Id);
            if (post == null) throw new Exception("Not Found");
            post.Username = request.Username;
            post.DateCreated = request.DateCreated;
            post.Text = request.Text;
            _unitOfWork.blogRepository.Update(post);
            await _unitOfWork.SaveAsync();
            return post.Id;
        }
    }
}
