using CMSApplication.Contracts;

namespace CMSApplication.Entities
{
    public class In_appMessaging : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ActionButtonText { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDismissible { get; set; }
        public int CharityHomeId { get; set; }
        public string CampaignId { get; set; }
        public IList<CharityHome> CharityHomes { get; set; } = new List<CharityHome>();
    }
}