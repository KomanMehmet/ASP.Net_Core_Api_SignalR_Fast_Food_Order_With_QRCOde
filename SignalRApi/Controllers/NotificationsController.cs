using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.NotificationDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult GetNotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("GetNotificationByStatusFalse")]
        public IActionResult GetNotificationByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("TNotificationsByStatusFalse")]
        public IActionResult TNotificationsByStatusFalse()
        {
            return Ok(_notificationService?.TNotificationsByStatusFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification
            {
                NotificationDate = createNotificationDto.NotificationDate,
                NotificationDescription = createNotificationDto.NotificationDescription,
                NotificationType = createNotificationDto.NotificationType,
                NotificationIcon = createNotificationDto.NotificationIcon,
                NotificationStatus = false,
            };

            _notificationService.TAdd(notification);

            return Ok("Notification Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);

            _notificationService.TDelete(value);

            return Ok("Notification Silindi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification
            {
                NotificationDate = updateNotificationDto.NotificationDate,
                NotificationDescription = updateNotificationDto.NotificationDescription,
                NotificationType = updateNotificationDto.NotificationType,
                NotificationIcon = updateNotificationDto.NotificationIcon,
                NotificationStatus = updateNotificationDto.NotificationStatus,
                NotificationID = updateNotificationDto.NotificationID
            };

            _notificationService.TUpdate(notification);

            return Ok("Notification Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);

            return Ok(value);
        }
    }
}
