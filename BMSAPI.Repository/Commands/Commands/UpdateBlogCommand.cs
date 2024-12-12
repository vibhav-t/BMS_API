using MediatR;

namespace BMSAPI.Repository.Commands.Command
{
    public class UpdateBlogCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
        public string Text { get; set; }
    }
}
