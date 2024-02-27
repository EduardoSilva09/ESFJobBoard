using ESFJobBoard.Core.Enums;

namespace ESFJobBoard.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string username, string password, UserTypeEnum userType)
        {
            Username = username;
            Password = password;
            UserType = userType;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
        // Navigation properties
        public ICollection<JobApplication> Applications { get; set; }
    }

}