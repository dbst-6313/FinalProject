using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext northwind = new NorthwindContext())
            {
                var addedEntity = northwind.Entry(entity);
                addedEntity.State = EntityState.Added;
                northwind.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext northwind = new NorthwindContext())
            {
                var removedEntity = northwind.Remove(entity);
                removedEntity.State = EntityState.Deleted;
                northwind.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filte = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filte == null ? context.Set<Product>().ToList():context.Set<Product>().Where(filte).ToList();
            }
           
        }

        public void Update(Product entity)
        {
            using (NorthwindContext northwind = new NorthwindContext())
            {
                var updatedEntity = northwind.Update(entity);
                updatedEntity.State = EntityState.Modified;
                northwind.SaveChanges();
            }
        }
    }
}
