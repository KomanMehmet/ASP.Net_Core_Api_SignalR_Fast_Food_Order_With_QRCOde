using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonilDal
    {
        public EfTestimonialDal(SignalIRContext context) : base(context)
        {
        }
    }
}
