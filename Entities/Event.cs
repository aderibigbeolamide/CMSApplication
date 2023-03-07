using CMSApp.Contracts;

namespace CMSApp.Entities
{
    public class Event : AuditableEntity
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventImage { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public DateTime EventDate { get; set; }
        public int CharityHomeId { get; set; }
    }
}