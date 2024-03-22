using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(SignalIRContext context) : base(context)
        {
        }

        public int MenuTableCount()
        {
            using var context = new SignalIRContext();

            return context.MenuTables.Count();
        }
    }
}
