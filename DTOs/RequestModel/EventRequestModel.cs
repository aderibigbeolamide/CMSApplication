using System.ComponentModel.DataAnnotations;

namespace CMSApp.DTOs.RequestModel
{
    public class EventRequestModel
    {
        public string EventName { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
    }

    public class UpdateEventRequestModel
    {
        public string EventName { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
    }
}