using MediatR;

namespace BMSAPI.Repository.Commands.Command
{
    public class CreateBlogCommand:IRequest<int>
    {
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
