using ESFJobBoard.Core.Entities;
using ESFJobBoard.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace ESFJobBoard.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JobBoardDbContext _dbContext;

        public UserRepository(JobBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var userToRemove = await _dbContext.Users.FindAsync(userId);
            if (userToRemove != null)
            {
                _dbContext.Users.Remove(userToRemove);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}