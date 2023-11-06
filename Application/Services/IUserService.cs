using Persistence.Entity;

namespace Application.Services
{
    public interface IUserService
    {
        Task CreateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task Update(User user,int id);
        Task Delete(int id);
    }
}
