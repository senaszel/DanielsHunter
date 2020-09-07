using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;

namespace DanielsHunter.Domain.Common
{
    public class Asset : BaseEntity
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public (int x, int y) Key { get { return (X, Y); } }
    }
}