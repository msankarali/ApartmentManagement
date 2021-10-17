using System.Collections.Generic;

namespace Core.Entities.PagedList
{
    public class PagedList<TEntity> : IPagedList<TEntity>
    {
        public int PageNumber { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public int TotalPages { get; }

        public bool HasPreviousPage => PageNumber > 0;

        public bool HasNextPage => PageNumber < TotalPages - 1;

        public IReadOnlyList<TEntity> Items { get; }

        public PagedList(int pageNumber, int pageSize, int totalCount, int totalPages, IReadOnlyList<TEntity> items)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
            Items = items;
        }
    }
}