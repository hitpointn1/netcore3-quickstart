using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quickstart.Repository.Entities;

namespace Quickstart.Repository.Extentions
{
    public static class EFExtentions
    {
        public static IQueryable<T> AsNoTracking<T>(this IQueryable<T> query,  bool hasTracking)
            where T : BaseEntity
        {
            if (hasTracking)
                return query;
            else
                return query.AsNoTracking();
        }
    }
}
