using Microsoft.EntityFrameworkCore;
using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalIRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByTableNumber(int id)
        {
            using var context = new SignalIRContext();

            var values = context.Baskets.Where(x => x.MenuTableID == id).Include(y => y.Product).ToList();

            return values;
        }
    }
}
