using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal//IAboutDal'dan almamızın sebebi sonradan entitiye özgü method yazdığımızda oradan kolaylıkla erişelim.
    {
        public EfAboutDal(SignalIRContext context) : base(context)
        {
        }
    }
}
