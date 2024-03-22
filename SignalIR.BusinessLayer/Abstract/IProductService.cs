using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericServise<Product>
    {
        List<Product> TGetProductsWithCategories();

        int TGetProductCount();

        int TProductCountByCategoryNameHamburger();

        int TProductCountByCategoryNameDrink();

        string THighestPricedProductName();

        string TLowestPriceProductName();

        decimal TProductPriceAvg();

        decimal TProductPriceByHamburgerAvg();
    }
}
