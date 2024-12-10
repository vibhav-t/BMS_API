using BMSAPI.Entities.Model;
using Newtonsoft.Json;

namespace BMSAPI.Entities
{
    public class JsonFileService
    {
        private readonly string _filePath;
        public JsonFileService(string filePath)
        {
            _filePath = filePath;
        }
        public List<Blog> LoadBlogPosts()
        {
            if (!File.Exists(_filePath))
                return new List<Blog>();
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Blog>>(json) ?? new List<Blog>();
        }
        public void SaveBlogPosts(List<Blog> blogPosts) 
        {
            var json = JsonConvert.SerializeObject(blogPosts, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
