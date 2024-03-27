
using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface INotificationService : IGenericServise<Notification>
    {
        int TNotificationCountByStatusFalse();

        List<Notification> TNotificationsByStatusFalse();

        void TNotificationStatusChangeToFalse(int id);

        void TNotificationStatusChangeToTrue(int id);
    }
}
