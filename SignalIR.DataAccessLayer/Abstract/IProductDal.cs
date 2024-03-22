using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();

        int GetProductCount();

        int ProductCountByCategoryNameHamburger();

        int ProductCountByCategoryNameDrink();

        string HighestPricedProductName();

        string LowestPriceProductName();

        decimal ProductPriceAvg();

        decimal ProductPriceByHamburgerAvg();
    }
}
