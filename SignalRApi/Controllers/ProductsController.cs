using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new Product
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus
            };

            _productService.TAdd(product);

            return Ok("Product bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetById(id);

            _productService.TDelete(values);

            return Ok("Product bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product product = new Product
            {
                ProductID = updateProductDto.ProductID,
                ProductStatus = updateProductDto.ProductStatus,
                ProductName= updateProductDto.ProductName,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price

            };

            _productService.TUpdate(product);

            return Ok("Product bilgisi güncellendi.");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);

            return Ok(value);
        }
    }
}
