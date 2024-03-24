using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7074/api/Products");

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

                return View(value);
            }

            return View();
        }

        //Bunun view'i yok. Ayaxla Index tarafında işlem yaptık.
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto basketDto = new CreateBasketDto();
            basketDto.ProductID = id;

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(basketDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7074/api/Baskets/", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Json(basketDto);
        }
    }
}
