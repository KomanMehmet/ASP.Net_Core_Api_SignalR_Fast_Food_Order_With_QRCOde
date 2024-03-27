using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalIRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new SignalIRContext();

            return context.Notifications.Where(x => x.NotificationStatus == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalIRContext();

            return context.Notifications.Where(x => x.NotificationStatus == false).Count();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            using var context = new SignalIRContext();

            var value = context.Notifications.Find(id);

            value.NotificationStatus = false;

            context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            using var context = new SignalIRContext();

            var value = context.Notifications.Find(id);

            value.NotificationStatus = true;

            context.SaveChanges();
        }
    }
}
