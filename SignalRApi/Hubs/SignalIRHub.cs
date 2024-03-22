using Microsoft.AspNetCore.SignalR;
using SignalIR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalIRHub : Hub
    {
        SignalIRContext context = new SignalIRContext();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();

            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
