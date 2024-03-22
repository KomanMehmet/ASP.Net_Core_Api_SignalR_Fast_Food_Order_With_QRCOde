
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.Abstract
{
    public interface IMoneyCaseDal : IGenericDal<MoneyCase>
    {
        decimal TotalMoneyCaseAmount();
    }
}
