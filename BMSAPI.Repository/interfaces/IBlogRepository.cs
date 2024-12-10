using BMSAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSAPI.Repository.interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(int id);
        void Add(Blog post);
        void Update(Blog post);
        void Delete(Blog post);
        void SaveChanges();
    }
}
