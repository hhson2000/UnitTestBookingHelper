using System.Linq;

namespace BookingHelper.Service
{
    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }
}