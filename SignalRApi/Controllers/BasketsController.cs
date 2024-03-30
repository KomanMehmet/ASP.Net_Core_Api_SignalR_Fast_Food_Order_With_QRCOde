using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("GetBasketByTableNumber")]
        public IActionResult GetBasketByTableNumber(int id)
        {
            return Ok(_basketService.TGetBasketByTableNumber(id));
        }

        [HttpGet("BasketListByMenuTableWtihProductName")]
        public IActionResult BasketListByMenuTableWtihProductName(int id)
        {
            using var context = new SignalIRContext();

            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                BasketID = z.BasketID,
                ProductCount = z.ProductCount,
                MenuTableID = z.MenuTableID,
                ProductPrice = z.ProductPrice,
                ProductID = z.ProductID,
                ProductTotalPrice = z.ProductTotalPrice,
                ProductName = z.Product.ProductName

            }).ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            //QR CODE canlıya alınırsa burada bu işlemler olacak.


            using var context = new SignalIRContext();

            _basketService.TAdd(new Basket
            {
                ProductID =createBasketDto.ProductID,
                ProductCount = 1,
                MenuTableID = 1,
                ProductPrice = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                ProductTotalPrice = 0                
            });

            return Ok("Sepete Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var  value = _basketService.TGetById(id);

            _basketService.TDelete(value);

            return Ok("Basket silindi");
        }
    }
}
