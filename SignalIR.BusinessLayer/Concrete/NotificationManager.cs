using SignalIR.BusinessLayer.Abstract;
using SignalIR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TGetListAll()
        {
            return _notificationDal.GetListAll();
        }

        public int TNotificationCountByStatusFalse()
        {
            return _notificationDal.NotificationCountByStatusFalse();
        }

        public List<Notification> TNotificationsByStatusFalse()
        {
            return _notificationDal.GetAllNotificationByFalse();
        }

        public void TNotificationStatusChangeToFalse(int id)
        {
            _notificationDal.NotificationStatusChangeToFalse(id);
        }

        public void TNotificationStatusChangeToTrue(int id)
        {
            _notificationDal.NotificationStatusChangeToTrue(id);
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
