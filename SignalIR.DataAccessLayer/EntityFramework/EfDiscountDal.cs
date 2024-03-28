using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalIRContext context) : base(context)
        {
        }

        public void ChangeStatusToFalse(int id)
        {
            using var context = new SignalIRContext();

            var value = context.Discounts.Find(id);

            value.Status = false;

            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            using var context = new SignalIRContext();

            var value = context.Discounts.Find(id);

            value.Status = true;

            context.SaveChanges();
        }

        public List<Discount> GetDiscountListByStatusTrue()
        {
            using var context = new SignalIRContext();

            var value = context.Discounts.Where(c => c.Status == true).ToList();

            return value;
        }
    }
}
