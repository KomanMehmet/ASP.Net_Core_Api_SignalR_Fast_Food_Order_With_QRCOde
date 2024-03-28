namespace SignalRWebUI.Dtos.BookingDtos
{
    public class GetBookingDto
    {
        public int BookingID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

		public string ReservationDescription { get; set; }

		public string Email { get; set; }

        public int PersonCount { get; set; }

        public DateTime Date { get; set; }
    }
}
