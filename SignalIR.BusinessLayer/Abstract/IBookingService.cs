using SignalIR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericServise<Booking>
    {
		void TBookingStatusApproved(int id);

		void TBookingStatusCancelled(int id);

	}
}
