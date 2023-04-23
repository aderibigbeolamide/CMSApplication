using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.Interfaces.Services
{
    public interface IEventService
    {
        Task<BaseResponse> AddEvent(EventRequestModel model);
        Task<BaseResponse> UpdateEvent(UpdateEventRequestModel model, int id);
        Task<EventResponseModel> GetAllEvent();
        Task<BaseResponse> DeleteEvent(int Id);
        Task<EventResponseModel> GetEventByName(string Name);

    }
}