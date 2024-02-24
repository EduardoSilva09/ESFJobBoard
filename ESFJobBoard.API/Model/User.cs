using ESFJobBoard.API.Enums;

namespace ESFJobBoard.API.Model
{
    public class User : BaseEntity
    {

        public User(string username, string password, UserTypeEnum userType)
        {
            this.Username = username;
            this.Password = password;
            this.UserType = userType;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
    }

}