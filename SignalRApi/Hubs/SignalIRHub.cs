using Microsoft.AspNetCore.SignalR;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalIRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;

        public SignalIRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
        }

        public async Task SendStatistic()
        {
            var categoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var productCount = _productService.TGetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var productCountByCategoryNameHamburger = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", productCountByCategoryNameHamburger);

            var productCountByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", productCountByCategoryNameDrink);

            var highestPricedProductName = _productService.THighestPricedProductName();
            await Clients.All.SendAsync("ReceiveHighestPricedProductName", highestPricedProductName);

            var lowestPricedProductName = _productService.TLowestPriceProductName();
            await Clients.All.SendAsync("ReceiveLowestPricedProductName", lowestPricedProductName);

            var productPriceAvarage = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvarage", productPriceAvarage.ToString("0.00" + " ₺"));

            var productPriceByHamburgerAvarage = _productService.TProductPriceByHamburgerAvg();
            await Clients.All.SendAsync("ReceiveProductPriceByHamburgerAvg", productPriceByHamburgerAvarage.ToString("0.00" + " ₺"));

            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00" + " ₺"));

            var totalMoneyCaseAmount = _moneyCaseService.TtotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00" + " ₺"));

            var menuTableCount = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTableCount);
        }

        public async Task SendProgress()
        {
            var totalPriceInCash = _moneyCaseService.TtotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalPriceInCash", totalPriceInCash.ToString("0.00" + " ₺"));

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var activeTableCount = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveActiveTableCount", activeTableCount);
        }

        public async Task GetBookingList()
        {
            var bookingList = _bookingService.TGetListAll();

            await Clients.All.SendAsync("ReceiveBookingList", bookingList);
        }

    }
}
