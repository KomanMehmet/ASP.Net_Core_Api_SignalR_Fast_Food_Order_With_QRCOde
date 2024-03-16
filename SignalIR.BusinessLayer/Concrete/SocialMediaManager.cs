using SignalIR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaDal
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void Add(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }

        public void Delete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }

        public SocialMedia GetById(int id)
        {
            return _socialMediaDal.GetById(id);
        }

        public List<SocialMedia> GetListAll()
        {
            return _socialMediaDal.GetListAll();
        }

        public void Update(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
