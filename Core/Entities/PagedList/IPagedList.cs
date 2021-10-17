using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.PagedList
{
    public interface IPagedList<out T>
    {
        int PageNumber { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        IReadOnlyList<T> Items { get; }
        public T this[int index] => Items.ElementAt(index);
    }
}