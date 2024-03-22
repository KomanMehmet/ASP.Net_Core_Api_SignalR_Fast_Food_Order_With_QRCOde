using Microsoft.EntityFrameworkCore;
using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalIRContext context) : base(context)
        {
        }

        public int GetProductCount()
        {
            using var context = new SignalIRContext();

            return context.Products.Count();
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalIRContext();

            var value = context.Products.Include(x => x.Category).ToList();

            return value;
        }

        public string HighestPricedProductName()
        {
            using var context = new SignalIRContext();

            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string LowestPriceProductName()
        {
            using var context = new SignalIRContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new SignalIRContext();

            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalIRContext();

            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalIRContext();

            //Fiyat ortalamasını döner
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductPriceByHamburgerAvg()
        {
            using var context = new SignalIRContext();

            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.Price);
        }
    }
}
