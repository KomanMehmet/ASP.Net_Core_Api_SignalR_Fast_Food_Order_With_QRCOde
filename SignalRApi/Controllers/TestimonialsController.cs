using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.TestimonialDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialsController(ITestimonialService TestimonialService)
        {
            _testimonialService = TestimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial testimonial = new Testimonial
            {
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Status = createTestimonialDto.Status,
                Title = createTestimonialDto.Title
            };

            _testimonialService.TAdd(testimonial);

            return Ok("Testimonial bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);

            _testimonialService.TDelete(values);

            return Ok("Testimonial bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial testimonial = new Testimonial
            {
                TestimonialID = updateTestimonialDto.TestimonialID,
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                Status = updateTestimonialDto.Status,
                Name = updateTestimonialDto.Name,
                ImageUrl = updateTestimonialDto.ImageUrl
            };

            _testimonialService.TUpdate(testimonial);

            return Ok("Testimonial bilgisi güncellendi.");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);

            return Ok(value);
        }
    }
}
