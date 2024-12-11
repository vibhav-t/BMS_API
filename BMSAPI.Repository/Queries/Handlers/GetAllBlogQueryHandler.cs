using BMSAPI.Entities.Model;
using BMSAPI.Repository.interfaces;
using BMSAPI.Repository.Queries.Queries;
using MediatR;

namespace BMSAPI.Repository.Queries.Handlers
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery, IEnumerable<Blog>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllBlogQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Blog>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.blogRepository.GetAllAsync();
        }
    }
}
