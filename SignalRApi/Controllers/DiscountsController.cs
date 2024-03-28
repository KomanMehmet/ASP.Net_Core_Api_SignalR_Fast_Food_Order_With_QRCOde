using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.DiscountDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService DiscountService)
        {
            _discountService = DiscountService;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _discountService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            Discount Discount = new Discount
            {
                Title = createDiscountDto.Title,
                Description = createDiscountDto.Description,
                Amount = createDiscountDto.Amount,
                ImageURL = createDiscountDto.ImageURL,
                Status = false
            };

            _discountService.TAdd(Discount);

            return Ok("Discount bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _discountService.TGetById(id);

            _discountService.TDelete(values);

            return Ok("Discount bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            Discount Discount = new Discount
            {
                DiscountID = updateDiscountDto.DiscountID,
                Title = updateDiscountDto.Title,
                Description = updateDiscountDto.Description,
                Amount= updateDiscountDto.Amount,
                ImageURL = updateDiscountDto.ImageURL,
                Status = updateDiscountDto.Status,
            };

            _discountService.TUpdate(Discount);

            return Ok("Discount bilgisi güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);

            return Ok(value);
        }

        [HttpGet("ChangeStatusToTrue")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);

            return Ok("Discount status aktif hale getirildi.");
        }

        [HttpGet("ChangeStatusToFalse")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);

            return Ok("Discount status pasif hale getirildi.");
        }

        [HttpGet("GetDiscountByStatusTrue")]
        public IActionResult GetDiscountByStatusTrue()
        {
            return Ok(_discountService.TGetDiscountListByStatusTrue());
        }

    }
}
