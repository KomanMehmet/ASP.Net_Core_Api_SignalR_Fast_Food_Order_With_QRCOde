using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericServise<Product>
    {
        List<Product> TGetProductsWithCategories();
    }
}
