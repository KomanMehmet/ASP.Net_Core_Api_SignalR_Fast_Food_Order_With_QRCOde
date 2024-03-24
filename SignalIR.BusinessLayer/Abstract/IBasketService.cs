
using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface IBasketService : IGenericServise<Basket>
    {
        List<Basket> TGetBasketByTableNumber(int id);
    }
}
