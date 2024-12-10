using MediatR;

namespace BMSAPI.Repository.Commands.Command
{
    public class UpdateBlogCommand:IRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
