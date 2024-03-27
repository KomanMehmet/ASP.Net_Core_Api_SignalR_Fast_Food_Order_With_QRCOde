using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.MenuTableDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.TGetListAll();

			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			MenuTable menutable = new MenuTable
			{
				Name = createMenuTableDto.Name,
				Status = createMenuTableDto.Status
			};

			_menuTableService.TAdd(menutable);

			return Ok("MenuTable bilgisi eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var values = _menuTableService.TGetById(id);

			_menuTableService.TDelete(values);

			return Ok("MenuTable bilgisi silindi");
		}

		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			MenuTable MenuTable = new MenuTable
			{
				MenuTableID = updateMenuTableDto.MenuTableID,
				Name = updateMenuTableDto.Name,
				Status = updateMenuTableDto.Status
			};

			_menuTableService.TUpdate(MenuTable);

			return Ok("MenuTable bilgisi güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);

			return Ok(value);
		}
	}
}
