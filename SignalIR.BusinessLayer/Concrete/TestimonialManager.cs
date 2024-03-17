using SignalIR.BusinessLayer.Abstract;
using SignalIR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonilDal _testimonilDal;

        public TestimonialManager(ITestimonilDal testimonilDal)
        {
            _testimonilDal = testimonilDal;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonilDal.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _testimonilDal.Delete(entity);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonilDal.GetById(id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _testimonilDal.GetListAll();
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonilDal.Update(entity);
        }
    }
}
