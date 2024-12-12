using BMSAPI.Entities.Model;
using BMSAPI.Repository.Commands.Command;
using BMSAPI.Repository.interfaces;
using MediatR;

namespace BMSAPI.Entities.Commands.Handlers
{
    public class DeleteBlogCommandHandler:IRequestHandler<DeleteBlogCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.blogRepository.GetByIdAsync(request.Id);
            if (post == null) throw new Exception("Not Found");
            _unitOfWork.blogRepository.Delete(post);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
