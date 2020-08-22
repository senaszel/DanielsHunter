using System.Linq;

namespace DanielsHunter
{
    public class UserService
    {
        public User User { get; set; }
        public UserService()
        {
            User = new User();
        }
        public UserService(User user)
        {
            User = user;
        }
    }
}
