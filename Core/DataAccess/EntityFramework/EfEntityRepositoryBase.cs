using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> :  IEntityRepository<TEntity>
    where TEntity:class,IEntity,new() 
    where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext northwind = new TContext())
            {
                var addedEntity = northwind.Entry(entity);
                addedEntity.State = EntityState.Added;
                northwind.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext northwind = new TContext())
            {
                var removedEntity = northwind.Remove(entity);
                removedEntity.State = EntityState.Deleted;
                northwind.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filte = null)
        {
            using (TContext context = new TContext())
            {
                return filte == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filte).ToList();
            }

        }

        public void Update(TEntity entity)
        {
            using (TContext northwind = new TContext())
            {
                var updatedEntity = northwind.Update(entity);
                updatedEntity.State = EntityState.Modified;
                northwind.SaveChanges();
            }
        }
    }
}
