﻿using Microsoft.AspNetCore.SignalR;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using System.Configuration;

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
        private readonly INotificationService _notificationService;

        public SignalIRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public static int ClientCount = 0;

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

        public async Task GetNotificationListByStatusFalse()
        {
            var notificationListCountByStatusFalse = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationListCountByStatusFalse", notificationListCountByStatusFalse);

            var notificationListByStatusFalse = _notificationService.TNotificationsByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByStatusFalse", notificationListByStatusFalse);
        }

        public async Task GetMenuTableStatus()
        {
            var getMenuTableStatus = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveGetMenuTableStatus", getMenuTableStatus);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        //Client'e bağlı olan client sayısını getiriyor.
        public override async Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
