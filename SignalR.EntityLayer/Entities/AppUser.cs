using Microsoft.AspNetCore.Identity;

namespace SignalR.EntityLayer.Entities
{
    public class AppUser : IdentityUser<int>//id'yi default olarak string veriyor. Biz projede int olarak çalıştığımız için int olarak vermesini istiyoruz.
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
