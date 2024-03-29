namespace CMSApplication.DTOs
{
    public class CampaignDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TargetAudience { get; set; }
        public decimal Budget { get; set; }
        public bool IsActive { get; set; }
    }
}