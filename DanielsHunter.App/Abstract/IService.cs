using DanielsHunter.Domain.Entity;
using System.Collections.Generic;
namespace DanielsHunter.App.Abstract
{
    public interface IService<T> where T : BaseEntity
    {
        List<T> Items { get; set; }
        List<T> GetAllItems();
        int AddItem(T item);
        int UpdateItem(T item);
        void RemoveItem(T item);

    }
}
