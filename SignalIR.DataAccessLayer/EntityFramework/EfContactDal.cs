using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(SignalIRContext context) : base(context)
        {
        }
    }
}
