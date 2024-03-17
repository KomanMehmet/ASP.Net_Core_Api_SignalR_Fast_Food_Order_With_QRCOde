using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingsController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _BookingService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking Booking = new Booking
            {
                Date = DateTime.Now,
                Email = createBookingDto.Email,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                PhoneNumber = createBookingDto.PhoneNumber
            };

            _BookingService.TAdd(Booking);

            return Ok("Booking bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var values = _BookingService.TGetById(id);

            _BookingService.TDelete(values);

            return Ok("Booking bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking Booking = new Booking
            {
                BookingID = updateBookingDto.BookingID,
                PhoneNumber = updateBookingDto.PhoneNumber,
                PersonCount = updateBookingDto.PersonCount,
                Name = updateBookingDto.Name,
                Email = updateBookingDto.Email,
                Date = updateBookingDto.Date
            };

            _BookingService.TUpdate(Booking);

            return Ok("Booking bilgisi güncellendi.");
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var value = _BookingService.TGetById(id);

            return Ok(value);
        }
    }
}
