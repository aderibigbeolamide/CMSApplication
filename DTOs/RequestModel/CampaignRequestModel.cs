namespace CMSApplication.DTOs.RequestModel
{
    public class CampaignRequestModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TargetAudience { get; set; }
        public decimal Budget { get; set; }
    }
}