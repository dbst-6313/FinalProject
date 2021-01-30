using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService product = new ProductManager(new InMemoryProductDal());
            foreach (var item in product.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
