using DanielsHunter.App.Common;
using DanielsHunter.Domain.Entity;
using System.Linq;

namespace DanielsHunter.App.Concrete
{
    public class BoardService : BaseService<Board>
    {
        public Board Board { get { return Current as Board; } }
    }
}
