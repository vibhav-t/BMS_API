using BMSAPI.Entities.Model;
using BMSAPI.Repository.interfaces;
using BMSAPI.Repository.Queries.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSAPI.Repository.Queries.Handlers
{
    public class GetBlogByIDQueryHandler:IRequestHandler<GetBlogByIDQuery,Blog>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBlogByIDQueryHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Blog> Handle(GetBlogByIDQuery request, CancellationToken cancellationToken)
        {
            var response= await _unitOfWork.blogRepository.GetByIdAsync(request.Id);
            if (response == null) throw new Exception("Not Found");
            return response;

        }
    }
}
