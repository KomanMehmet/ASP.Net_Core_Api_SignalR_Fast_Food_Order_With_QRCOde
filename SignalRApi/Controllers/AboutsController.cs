using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.AboutDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl
            };

            _aboutService.TAdd(about);

            return Ok("Hakkında bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetById(id);

            _aboutService.TDelete(values);

            return Ok("Hakkında bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About 
            {
                AboutID = updateAboutDto.AboutID,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl
            };

            _aboutService.TUpdate(about);

            return Ok("Hakkında bilgisi güncellendi.");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);

            return Ok(value);
        }
    }
}
