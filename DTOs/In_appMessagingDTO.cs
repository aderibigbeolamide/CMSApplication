namespace CMSApplication.DTOs
{
    public class In_appMessagingDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ActionButtonText { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDismissible { get; set; }
        public int CharityHomeId { get; set; }
        public string CampaignId { get; set; }
    }
}