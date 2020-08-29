using DanielsHunter.App.Common;
using DanielsHunter.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter.App.Concrete
{
    public class ScreenService : BaseService<BaseEntity>
    {
        public Screen Screen { get { return (Screen)GetFirstItem(); } }
    }
}
