using SignalR.EntityLayer.Entities;


namespace SignalIR.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericServise<Order>
    {
        int TTotalOrderCount();

        int TActiveOrderCount();

        decimal TLastOrderPrice();

        decimal TtodayTotalPrice();
    }
}
