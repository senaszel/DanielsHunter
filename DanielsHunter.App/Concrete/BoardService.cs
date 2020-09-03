using DanielsHunter.App.Common;
using DanielsHunter.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter.App.Concrete
{
    public class BoardService : BaseService<Board>
    {
        public Board Board { get { return (Board)GetFirstItem(); } }
    }
}
