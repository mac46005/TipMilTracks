using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TipMilTracks.Repositories
{
    public interface IRepository<T>
    {
        event EventHandler<T> OnItemAdded;
        event EventHandler<T> OnItemUpdated;
        event EventHandler<T> OnItemDeleted;

        Task<T> GetItem(T item);
        Task<List<T>> GetItems();
        Task AddItem(T item);
        Task UpdateItem(T item);
        Task AddOrUpdateItem(T item);
        Task DeleteItem(T item);
    }
}
