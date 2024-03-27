using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();

        List<Notification> GetAllNotificationByFalse();

        void NotificationStatusChangeToTrue(int id);

        void NotificationStatusChangeToFalse(int id);
    }
}
