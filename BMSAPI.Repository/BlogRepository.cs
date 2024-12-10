using BMSAPI.Entities;
using BMSAPI.Entities.Model;
using BMSAPI.Repository.interfaces;


namespace BMSAPI.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly JsonFileService _jsonFileStorageService;
        private List<Blog> _blogPosts;
        public BlogRepository(JsonFileService jsonFileStorageService)
        {
            _jsonFileStorageService = jsonFileStorageService;
            _blogPosts = _jsonFileStorageService.LoadBlogPosts();
        }
        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await Task.FromResult(_blogPosts);
        }
        public async Task<Blog> GetByIdAsync(int id)
        {
            return await Task.FromResult(_blogPosts.FirstOrDefault(p => p.Id == id));
        }
        public void Add(Blog post)
        {
            post.Id = _blogPosts.Any() ? _blogPosts.Max(p => p.Id) + 1 : 1; _blogPosts.Add(post);
        }
        public void Update(Blog post)
        {
            var existingPost = _blogPosts.FirstOrDefault(p => p.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.Username = post.Username;
                existingPost.DateCreated = post.DateCreated;
                existingPost.Text = post.Text;
            }
        }
        public void Delete(Blog post)
        {
            _blogPosts.Remove(post);
        }
        public void SaveChanges()
        {
            _jsonFileStorageService.SaveBlog(_blogPosts);
        }
    }
}
