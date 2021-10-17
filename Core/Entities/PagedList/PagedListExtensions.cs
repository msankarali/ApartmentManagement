using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Entities.PagedList
{
    public static class PagedListExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source,
            int pageSize,
            int pageNumber = 0)
        {
            int count = source.Count();
            int totalPages = (int)Math.Ceiling((double)count / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (pageNumber >= totalPages) throw new Exception("404 ^__^");
            var pagedList = source.Skip(pageNumber * pageSize).Take(pageSize);
            return new PagedList<T>(pageNumber, pageSize, count, totalPages, pagedList.ToList());
        }

        public static IPagedList<TResult> ToPagedList<TEntity, TResult>(this IQueryable<TEntity> source,
            int pageSize,
            int pageNumber = 0,
            Expression<Func<TEntity, TResult>> selector = null)
        {
            int count = source.Count();
            int totalPages = (int)Math.Ceiling((double)count / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (pageNumber >= totalPages) throw new Exception("404 ^__^");
            source = source.Skip(pageNumber * pageSize).Take(pageSize);
            var pagedList = new List<TResult>();
            if (selector != null) pagedList = new List<TResult>(source.Select(selector));
            return new PagedList<TResult>(pageNumber, pageSize, count, totalPages, pagedList);
        }

        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source,
            int pageSize,
            int pageNumber, 
            int totalCount, 
            int totalPages)
        {
            if (totalPages == 0) totalPages = 1;
            if (pageNumber >= totalPages) throw new Exception("404 ^__^");
            return new PagedList<T>(pageNumber, pageSize, totalCount, totalPages, source.ToList());
        }
    }
}