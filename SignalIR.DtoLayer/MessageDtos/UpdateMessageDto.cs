namespace SignalIR.DtoLayer.MessageDtos
{
    public class UpdateMessageDto
    {
        public int MessageID { get; set; }

        public string NameSurname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime SendDate { get; set; }

        public bool Status { get; set; }
    }
}
