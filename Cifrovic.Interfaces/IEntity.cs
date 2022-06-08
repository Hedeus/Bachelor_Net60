using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cifrovik.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public interface IRepository<T> where T : class, IEntity, new()
    {
        bool AutosaveChanges { get; set; }
        IQueryable<T> Items { get; }
        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken Cancel = default);
        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken Cancel = default);
        void Update(T item);
        Task UpdateAsync(T item, CancellationToken Cancel = default);
        void Remove(int id);
        Task RemoveAsync(int id, CancellationToken Cancel = default);
        void AutosaveOnOff(bool autosave);
        void Save();
        Task SaveAsync(CancellationToken Cancel = default);
    }
}
