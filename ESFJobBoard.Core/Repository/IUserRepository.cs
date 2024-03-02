using ESFJobBoard.Core.Entities;

namespace ESFJobBoard.Core.Repository
{
    public interface IUserRepository
    {
        // Retrieve a user by their unique identifier
        Task<User?> GetUserByIdAsync(int userId);
        // Retrieve a user by their username
        Task<User?> GetUserByUsernameAsync(string username);
        // Add a new user to the repository
        Task AddUserAsync(User user);
        // Update user information
        Task UpdateUserAsync(User user);
        // Delete a user from the repository
        Task DeleteUserAsync(User user);
        // Get all users in the repository
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}