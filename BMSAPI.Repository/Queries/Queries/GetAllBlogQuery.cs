using BMSAPI.Entities.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSAPI.Repository.Queries.Queries
{
    public class GetAllBlogQuery:IRequest<IEnumerable<Blog>>
    {
    }
}
