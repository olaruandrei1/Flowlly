using System.Linq.Expressions;

namespace Ollyware.Flowlly.Core.API.Domain.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyFilters<T, TFilter>(this IQueryable<T> query, TFilter? filter)
    {
        if (filter is null)
            return query;

        var entityProps = typeof(T).GetProperties();

        foreach (var prop in typeof(TFilter).GetProperties())
        {
            var value = prop.GetValue(filter);

            if (value is null) continue;

            var entityProp = entityProps.FirstOrDefault(p => p.Name == prop.Name);

            if (entityProp is null) continue;

            var param = Expression.Parameter(typeof(T), "x");

            var left = Expression.Property(param, entityProp.Name);

            var right = Expression.Constant(value);

            Expression predicate;

            if (prop.PropertyType == typeof(string))
            {
                predicate = Expression.Call
                    (
                        left,
                        typeof(string).GetMethod("Contains", [typeof(string)])!,
                        right
                    );
            }
            else
            {
                predicate = Expression.Equal(left, right);
            }

            query = query.Where
                (
                    Expression.Lambda<Func<T, bool>>(predicate, param)
                );
        }

        return query;
    }
}
