using CMSApplication.Entities;

namespace CMSApplication.DTOs.RequestModel
{
    public class AppointmentRequestModel
    {
       
    }
    public class CreateAppointmentRequestModel
    {
        public DateTime Time { get; set; }
        
    }

    public class UpdateAppointmentRequestModel
    {
        public bool IsAccomplished { get; set; }
        public DateTime Time { get; set; }
        public bool IsApproved { get; set; }
    }
}
