using Persistence.Entity;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task Update(User user,int id);
        Task Delete(int id);
    }
}
