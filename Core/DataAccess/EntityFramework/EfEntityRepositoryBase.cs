using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities.PagedList;

namespace Core.DataAccess.EntityFramework
{
    public abstract class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        protected EfEntityRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }
        public TEntity GetFirst(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query.AsNoTracking();
            if (include != null) query = include(query);
            if (predicate != null) query = query.Where(predicate);
            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();
            return query.FirstOrDefault();
        }

        public List<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query.AsNoTracking();
            if (include != null) query = include(query);
            if (predicate != null) query = query.Where(predicate);
            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();
            return orderBy != null
                ? orderBy(query).ToList()
                : query.ToList();
        }

        public IReadOnlyList<TEntity> GetAllSelect<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query.AsNoTracking();
            if (include != null) query = include(query);
            if (predicate != null) query = query.Where(predicate);
            if (selector != null) query = (IQueryable<TEntity>)query.Select(selector).AsQueryable();
            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();
            return orderBy != null
                ? orderBy(query).ToList()
                : query.ToList();
        }

        public IPagedList<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, bool ignoreQueryFilters = false, int pageNumber = 0, int pageSize = 20)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query.AsNoTracking();
            if (include != null) query = include(query);
            if (predicate != null) query = query.Where(predicate);
            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();
            return orderBy != null
                ? orderBy(query).ToPagedList(pageSize, pageNumber)
                : query.ToPagedList(pageSize, pageNumber);
        }

        public IPagedList<TResult> GetAllPagedSelect<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false,
            int pageNumber = 0,
            int pageSize = 20)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query.AsNoTracking();
            if (include != null) query = include(query);
            if (predicate != null) query = query.Where(predicate);
            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();
            if (orderBy != null) query = orderBy(query);
            return query.ToPagedList(pageSize, pageNumber, selector);
        }

        public TEntity Add(TEntity entity, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public int Add(TEntity[] entities, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            _dbContext.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public int Add(IEnumerable<TEntity> entities, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            _dbContext.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public TEntity Update(TEntity entity, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public int Update(TEntity[] entities, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            _dbContext.Entry(entities).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int Update(IEnumerable<TEntity> entities, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            _dbContext.Entry(entities).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public TEntity Delete(TEntity entity, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return entity;
        }

        public int Delete(TEntity[] entities, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            _dbContext.Entry(entities).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public int Delete(object[] keyValues, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            TEntity entityToDelete = _dbContext.Set<TEntity>().Find(keyValues);
            _dbContext.Remove(entityToDelete);
            return _dbContext.SaveChanges();
        }

        public int Delete(IEnumerable<TEntity> entities, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters) _dbContext.Set<TEntity>().IgnoreQueryFilters();
            _dbContext.Entry(entities).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public int Count(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();
            if (include != null) query = include(query);
            return predicate == null
                ? query.Count()
                : query.Count(predicate);
        }

        public bool Any(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();
            if (include != null) query = include(query);
            return predicate == null
                ? query.Any()
                : query.Any(predicate);
        }
    }
}