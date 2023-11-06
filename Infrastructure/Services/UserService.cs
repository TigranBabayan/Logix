using Application.Repositories;
using Application.Services;
using Persistence.Entity;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateAsync(User user)
        {
            await _userRepository.CreateAsync(user);
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<List<User>> GetAllAsync()
        {
          return  await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
          return await _userRepository.GetByIdAsync(id);
        }

        public async Task Update(User user,int id)
        {
            await _userRepository.Update(user,id);
        }
    }
}
