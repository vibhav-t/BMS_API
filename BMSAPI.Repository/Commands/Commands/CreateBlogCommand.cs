using MediatR;

namespace BMSAPI.Repository.Commands.Command
{
    public class CreateBlogCommand:IRequest<int>
    {
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
        public string Text { get; set; }
    }
}
