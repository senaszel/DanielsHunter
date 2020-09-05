using DanielsHunter.App.Common;
using DanielsHunter.Domain.Entity;
using System.Linq;

namespace DanielsHunter.App.Concrete
{
    public class ScreenService : BaseService<Screen>
    {
        public Screen Screen { get { return Current as Screen; } }
    }
}
