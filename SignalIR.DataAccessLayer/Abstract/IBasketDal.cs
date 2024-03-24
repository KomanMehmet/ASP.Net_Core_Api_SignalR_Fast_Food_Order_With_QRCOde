using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        List<Basket> GetBasketByTableNumber(int id);
    }
}
