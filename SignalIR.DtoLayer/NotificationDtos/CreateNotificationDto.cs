namespace SignalIR.DtoLayer.NotificationDtos
{
    public class CreateNotificationDto
    {
        public string NotificationType { get; set; }

        public string NotificationIcon { get; set; }

        public string NotificationDescription { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool NotificationStatus { get; set; }
    }
}
