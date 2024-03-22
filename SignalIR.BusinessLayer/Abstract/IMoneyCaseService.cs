using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface IMoneyCaseService : IGenericServise<MoneyCase>
    {
        decimal TtotalMoneyCaseAmount();
    }
}
