using DanielsHunter.App.Common;
using DanielsHunter.Domain.Common;
using DanielsHunter.Domain.Entity;

namespace DanielsHunter.App.Concrete
{
    public class UserService : BaseService<Asset>
    {
        public User User { get { return GetItem(0) as User; } }
    }
}
