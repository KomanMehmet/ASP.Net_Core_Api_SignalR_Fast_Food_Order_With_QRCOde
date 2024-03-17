using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService FeatureService)
        {
            _featureService = FeatureService;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            Feature feature = new Feature
            {
                Description1 = createFeatureDto.Description1,
                Description2 = createFeatureDto.Description2,
                Description3 = createFeatureDto.Description3,
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Title3 = createFeatureDto.Title3
            };

            _featureService.TAdd(feature);

            return Ok("Feature bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.TGetById(id);

            _featureService.TDelete(values);

            return Ok("Feature bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            Feature feature = new Feature
            {
                FeatureID = updateFeatureDto.FeatureID,
                Title3 = updateFeatureDto.Title3,
                Title2 = updateFeatureDto.Title2,
                Title1 = updateFeatureDto.Title1,
                Description3 = updateFeatureDto.Description3,
                Description2 = updateFeatureDto.Description2,
                Description1 = updateFeatureDto.Description1,
            };

            _featureService.TUpdate(feature);

            return Ok("Feature bilgisi güncellendi.");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);

            return Ok(value);
        }
    }
}
