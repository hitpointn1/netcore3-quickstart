using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Quickstart.Repository.Extentions
{
    public static class EFExtentions
    {
        public static IQueryable<T> AsNoTracking<T>(this IQueryable<T> query,  bool hasTracking)
            where T : class
        {
            if (hasTracking)
                return query;
            else
                return query.AsNoTracking();
        }
    }
}
