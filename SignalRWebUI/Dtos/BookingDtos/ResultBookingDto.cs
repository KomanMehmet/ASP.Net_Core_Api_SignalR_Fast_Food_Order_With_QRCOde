﻿namespace SignalRWebUI.Dtos.BookingDtos
{
    public class ResultBookingDto
    {
        public int BookingID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int PersonCount { get; set; }

        public DateTime Date { get; set; }
    }
}
