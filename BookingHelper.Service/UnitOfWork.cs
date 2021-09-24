using System.Collections.Generic;
using System.Linq;

namespace BookingHelper.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        public IQueryable<T> Query<T>() => new List<T>().AsQueryable();
    }
}