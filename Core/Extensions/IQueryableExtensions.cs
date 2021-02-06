using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject filter,
        Expression<Func<T, object>> expression)
        {
            query = filter.IsAscending ? query.OrderBy(expression) : query.OrderByDescending(expression);

            return query;
        }
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject filter)
        {

            query = query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);

            return query;
        }

    }

}