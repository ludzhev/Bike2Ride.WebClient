using System.Linq;

using Bike2Ride.Data.Models.Contracts;

namespace Bike2Ride.Data.Contracts
{
    public interface IEFRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
