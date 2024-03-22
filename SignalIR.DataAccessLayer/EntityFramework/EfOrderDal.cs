using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalIRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalIRContext();

            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalIRContext();

            return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotelPrice).FirstOrDefault();
        }

        public int TotalOrderCount()
        {
            using var context = new SignalIRContext();

            return context.Orders.Count();
        }
    }
}
