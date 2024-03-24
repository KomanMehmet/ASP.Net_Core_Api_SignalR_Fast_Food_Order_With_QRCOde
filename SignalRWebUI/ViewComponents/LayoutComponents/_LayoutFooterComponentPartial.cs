using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutFooterComponentPartial : ViewComponent
	{
        public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
