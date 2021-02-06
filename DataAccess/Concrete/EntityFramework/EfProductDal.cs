using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailsDto> GetProductDetail()
        {
            using (NorthwindContext northwind = new NorthwindContext())
            {
                var result = from p in northwind.Products
                             join c in northwind.Categories on p.CategoryId equals c.CategoryId
                             select
                             new ProductDetailsDto 
                            { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };
                return result.ToList();
            }
            
           
        }
    }
}
