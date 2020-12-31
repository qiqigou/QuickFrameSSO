using Microsoft.EntityFrameworkCore;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int index, int size)
            where TSource : class
        {
            return source.Skip((index - 1) * size).Take(size).AsNoTracking();
        }
    }
}
