namespace SignalIR.DtoLayer.NotificationDtos
{
    public class GetNotificationDto
    {
        public int NotificationID { get; set; }

        public string NotificationType { get; set; }

        public string NotificationIcon { get; set; }

        public string NotificationDescription { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool NotificationStatus { get; set; }
    }
}
