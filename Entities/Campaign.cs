namespace CMSApp.Entities
{
    public class Campaign
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string TargetAudience { get; set; }
    public List<In_appMessaging> In_appMessagings_ { get; set; } = new List<In_appMessaging>();
    public decimal Budget { get; set; }
    public bool IsActive { get; set; }
}

}