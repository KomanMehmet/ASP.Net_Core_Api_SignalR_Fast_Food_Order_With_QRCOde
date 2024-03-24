namespace SignalIR.DtoLayer.BasketDtos
{
    public class CreateBasketDto
    {
        public decimal ProductPrice { get; set; }

        public int ProductCount { get; set; }

        public decimal ProductTotalPrice { get; set; }

        public int ProductID { get; set; }

        public int MenuTableID { get; set; }

    }
}
