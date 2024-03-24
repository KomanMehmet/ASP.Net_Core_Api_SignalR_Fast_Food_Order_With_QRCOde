using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookComponentPartial : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
