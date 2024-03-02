using ESFJobBoard.Core.Enums;

namespace ESFJobBoard.Core.Entities
{
    public class User(string firstName, string lastName, string email, string username, string password, UserTypeEnum userType) : BaseEntity
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;
        public UserTypeEnum UserType { get; set; } = userType;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        // Navigation properties        
        public ICollection<JobApplication> Applications { get; set; } = [];
    }

}