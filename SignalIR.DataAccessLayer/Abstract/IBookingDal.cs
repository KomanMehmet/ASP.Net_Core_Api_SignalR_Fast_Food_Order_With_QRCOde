using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusApproved(int id);

        void BookingStatusCancelled(int id);
    }
}
