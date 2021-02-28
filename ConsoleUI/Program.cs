using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            IProductService productService = new ProductManager(new EfProductDal());
            var result = productService.GetProductDetails();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.ProductName + "&&&&& " + item.CategoryName);
            }

        }

        private static void Test1()
        {
            ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryService.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void Test2()
        {
            IProductService product = new ProductManager(new EfProductDal());
            foreach (var item in product.GetByUnitPrice(20, 80).Data)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
