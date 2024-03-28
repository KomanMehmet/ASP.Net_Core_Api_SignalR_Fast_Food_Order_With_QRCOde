using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
	public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalIRContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var context = new SignalIRContext();

			var values = context.Bookings.Find(id);

			values.ReservationDescription = "Rezervasyon Onaylandı";

			context.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			using var context = new SignalIRContext();

			var values = context.Bookings.Find(id);

			values.ReservationDescription = "Rezervasyon İptal Edildi";

			context.SaveChanges();
		}
	}
}
