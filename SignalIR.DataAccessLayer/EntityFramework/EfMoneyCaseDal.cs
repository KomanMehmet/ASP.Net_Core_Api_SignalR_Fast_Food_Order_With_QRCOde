using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(SignalIRContext context) : base(context)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
            using var context = new SignalIRContext();

            return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
        }
    }
}
