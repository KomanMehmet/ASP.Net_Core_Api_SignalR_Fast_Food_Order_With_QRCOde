using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericServise<Discount>
    {
        void TChangeStatusToTrue(int id);

        void TChangeStatusToFalse(int id);
    }
}
