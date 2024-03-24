using SignalR.EntityLayer.Entities;

namespace SignalRApi.Models
{
    public class ResultBasketListWithProducts
    {
        public int BasketID { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductCount { get; set; }

        public decimal ProductTotalPrice { get; set; }

        public int ProductID { get; set; }

        public int MenuTableID { get; set; }

        public string ProductName { get; set; }
    }
}
