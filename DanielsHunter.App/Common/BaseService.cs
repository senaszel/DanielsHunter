using DanielsHunter.App.Abstract;
using DanielsHunter.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DanielsHunter.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        public BaseEntity Current { 
            get { return Items.Where(item => item.IsCurrent == true).FirstOrDefault(); }
            set { 
                Current.IsCurrent = false;
                Current = value;
                Current.IsCurrent = true;
            }
        }

        public BaseService()
        {
            Items = new List<T>();
        }

        public int AddItem(T item)
        {
            Items.Add(item);
            if (Items.Count == 1) { GetItem(0).IsCurrent = true; }
            return item.Id;
        }

        public BaseEntity GetItem(int Id)
        {
            return Items.FirstOrDefault(x => x.Id == Id);
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public int UpdateItem(T item)
        {
            var entity = Items.FirstOrDefault(p => p.Id == item.Id);
            if (entity != null)
            {
                entity = item;
            }
            return entity.Id;
        }
    }
}
