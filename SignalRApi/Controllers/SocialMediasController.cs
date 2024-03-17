using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.SocialMediaDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService SocialMediaService)
        {
            _socialMediaService = SocialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia
            {
                Icon = createSocialMediaDto.Icon,
                SocialMediaTitle = createSocialMediaDto.SocialMediaTitle,
                SocialMediaUrl = createSocialMediaDto.SocialMediaUrl
            };

            _socialMediaService.TAdd(socialMedia);

            return Ok("SocialMedia bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);

            _socialMediaService.TDelete(values);

            return Ok("SocialMedia bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia
            {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                SocialMediaUrl = updateSocialMediaDto.SocialMediaUrl,
                SocialMediaTitle = updateSocialMediaDto.SocialMediaTitle,
                Icon = updateSocialMediaDto.Icon  
            };

            _socialMediaService.TUpdate(socialMedia);

            return Ok("SocialMedia bilgisi güncellendi.");
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);

            return Ok(value);
        }
    }
}
