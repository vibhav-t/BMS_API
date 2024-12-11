using BMSAPI.Entities.Model;
using BMSAPI.Repository.Commands.Command;
using BMSAPI.Repository.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSAPI.Entities.Commands.Handlers
{
    public class DeleteBlogCommandHandler:IRequest<DeleteBlogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.blogRepository.GetByIdAsync(request.Id);
            //if (post == null) throw new NotFoundException(nameof(Blog), request.Id);
            _unitOfWork.blogRepository.Delete(post);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
