namespace CMSApplication.DTOs.ResponseModel
{
    public class EventResponseModel : BaseResponse
    {
        public EventDTO Data { get; set; }
    }

    public class EventsResponseModel : BaseResponse
    {
        public ICollection<EventDTO> Data { get; set; } = new HashSet<EventDTO>();
    }
}