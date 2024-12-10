using BMSAPI.Repository.interfaces;

namespace BMSAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBlogRepository _blogRepository { get; set; }

        public IBlogRepository blogRepository => _blogRepository;

        public UnitOfWork(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task SaveAsync()
        {
            _blogRepository.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
