namespace SignalR.EntityLayer.Entities
{
    public class Basket
    {
        public int BasketID { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductCount { get; set; }

        public decimal ProductTotalPrice { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }

        public int MenuTableID { get; set; }

        public MenuTable Menutable { get; set; }
    }
}
