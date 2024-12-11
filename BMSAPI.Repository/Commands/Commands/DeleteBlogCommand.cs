using BMSAPI.Entities.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSAPI.Repository.Commands.Command
{
    public class DeleteBlogCommand:IRequest
    {
        public int Id{get; set;}
        public DeleteBlogCommand(int blogId) 
        {
            Id = blogId;
        }
    }
}
