using StudentAPI.Data.Models;
using System.Reflection.Metadata;

namespace StudentAPI.Services.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Student>> GetAllBlogsAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student blog);
        Task<int> UpdateAsync(int id, Student blog);
        Task<int> DeleteAsync(int id);
    }
}
