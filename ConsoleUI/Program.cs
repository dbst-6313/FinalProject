using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService product = new ProductManager(new EfProductDal());
            foreach (var item in product.GetByUnitPrice(20,80))
            {
                Console.WriteLine(item.ProductName);
            }

        }
    }
}
