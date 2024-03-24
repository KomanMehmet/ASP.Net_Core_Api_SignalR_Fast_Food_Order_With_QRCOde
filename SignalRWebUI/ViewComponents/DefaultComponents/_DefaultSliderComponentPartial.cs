using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.FeatureDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var respoenseMessage = await client.GetAsync("https://localhost:7074/api/Features");

            if(respoenseMessage.IsSuccessStatusCode)
            {
                var jsonData = await respoenseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                return View(value);
            }

            return View();
        }
    }
}
