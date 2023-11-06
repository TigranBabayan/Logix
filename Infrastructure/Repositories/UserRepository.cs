using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Entity;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(User user)
        {
            if (user != null)
            {
                user.Password = user.Password.HashPasword();
                user.Address = user.Address.AddressFormating();
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            if (id != 0)
            {
                var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().Include(e => e.Classes).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            if (id != 0)
            {
                var user = await _context.Users.AsNoTracking().Include(c => c.Classes).FirstOrDefaultAsync(x => x.Id == id);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task Update(User user, int id)
        {
            if (id > 0)
            {
                var entity = await _context.Users.Include(c => c.Classes).FirstOrDefaultAsync(x => x.Id == id);
                entity.Address = user.Address;
                entity.PhoneNumber = user.PhoneNumber;
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.Email = user.Email;
                entity.DateOfBirth = user.DateOfBirth;
                entity.Role = user.Role;
                entity.Classes = user.Classes;
                entity.Password = user.Password;
                if (entity.Id != id && entity.ClassesId != user.ClassesId)
                {
                    try
                    {
                        entity.ClassesId = user.ClassesId;
                        await _context.SaveChangesAsync();
                    }
                    catch
                    {
                        throw new Exception("Only other users can edit their courses");
                    }
                    
                }
               }
            }
        }
    }

