using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Data.Models;
using StudentAPI.Services.Repositories;

namespace StudentAPI.Services
{
    public class StudentRepository : ICustomerRepository
    {
        private readonly AppDbContext appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Student> CreateAsync(Student blog)
        {
            await appDbContext.Students.AddAsync(blog);
            await appDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
          return await appDbContext.Students
          .Where(model => model.Id == id)
          .ExecuteDeleteAsync();
        }

        public Task<List<Student>> GetAllBlogsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, Student blog)
        {
            throw new NotImplementedException();
        }
    }
}
