using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities.Abstract;
using Core.Entities.PagedList;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.DataAccess.EntityFramework
{
    public interface IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        TEntity GetFirst(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false);

        List<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false);

        IReadOnlyList<TEntity> GetAllSelect<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false
        );

        IPagedList<TEntity> GetAllPaged(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false,
            int pageNumber = 0,
            int pageSize = 20
        );

        IPagedList<TResult> GetAllPagedSelect<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false,
            int pageNumber = 0,
            int pageSize = 20
        );

        TEntity Add(TEntity entity, bool ignoreQueryFilters = false);
        int Add(TEntity[] entities, bool ignoreQueryFilters = false);
        int Add(IEnumerable<TEntity> entities, bool ignoreQueryFilters = false);

        TEntity Update(TEntity entity, bool ignoreQueryFilters = false);
        int Update(TEntity[] entities, bool ignoreQueryFilters = false);
        int Update(IEnumerable<TEntity> entities, bool ignoreQueryFilters = false);

        TEntity Delete(TEntity entity, bool ignoreQueryFilters = false);
        int Delete(TEntity[] entities, bool ignoreQueryFilters = false);
        int Delete(object[] keyValues, bool ignoreQueryFilters = false);
        int Delete(IEnumerable<TEntity> entities, bool ignoreQueryFilters = false);

        int Count(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool ignoreQueryFilters = false);

        bool Any(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool ignoreQueryFilters = false);
    }
}