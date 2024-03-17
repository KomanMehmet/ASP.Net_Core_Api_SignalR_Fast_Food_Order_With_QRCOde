namespace SignalIR.DtoLayer.SocialMediaDtos
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaID { get; set; }

        public string SocialMediaTitle { get; }

        public string SocialMediaUrl { get; }

        public string Icon { get; set; }
    }
}
