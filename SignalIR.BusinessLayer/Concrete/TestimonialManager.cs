using SignalIR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonilDal
    {
        private readonly ITestimonilDal _testimonilDal;

        public TestimonialManager(ITestimonilDal testimonilDal)
        {
            _testimonilDal = testimonilDal;
        }

        public void Add(Testimonial entity)
        {
            _testimonilDal.Add(entity);
        }

        public void Delete(Testimonial entity)
        {
            _testimonilDal.Delete(entity);
        }

        public Testimonial GetById(int id)
        {
            return _testimonilDal.GetById(id);
        }

        public List<Testimonial> GetListAll()
        {
            return _testimonilDal.GetListAll();
        }

        public void Update(Testimonial entity)
        {
            _testimonilDal.Update(entity);
        }
    }
}
