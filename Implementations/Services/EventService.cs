using CMSApplication.DTOs;
using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Repositories;
using CMSApplication.Interfaces.Services;

namespace CMSApplication.Implementations.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ICharityHomeRepository _charityHomeRepository;

        public EventService(IEventRepository eventRepository, ICharityHomeRepository charityHomeRepository)
        {
            _charityHomeRepository = charityHomeRepository;
            _eventRepository = eventRepository;
        }

        public async Task<BaseResponse> AddEvent(EventRequestModel model)
        {
            var events = await _eventRepository.Get(x => x.EventName == model.EventName);
            if (events != null)
            {
                return new BaseResponse
                {
                    Message ="Event already exist",
                    Success = true
                };
            }
            var evt = new Event
            {
                EventName = model.EventName,
                EventDate = model.Date,
                Description = model.Description,
                EventImage = model.Image,
                Venue = model.Venue
            };
            await _eventRepository.Register(evt);
            return new BaseResponse
            {
                Message = "Event Added Successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> DeleteEvent(int Id)
        {
            var events = await _eventRepository.GetEventById(Id);
            if (events == null)
            {
                return new BaseResponse
                {
                    Message = "Event not found",
                    Success = false
                };
            }

            

            events.IsDeleted = true;
            events.DeletedOn = DateTime.Now;
            events.DeletedBy = Id;
            await _eventRepository.Update(events);

            return new BaseResponse
            {
                Message = "Event Deleted successfully",
                Success = true
            };
        }

        public async Task<EventResponseModel> GetAllEvent()
        {
            var events = await _eventRepository.GetAll();
            if (events == null)
            {
                return new EventResponseModel
                {
                    Message = "No available Event",
                    Success = false
                };
            }

            var ets = events.Select(x => new EventDTO
            {
                EventName = x.EventName,
                EventDate = x.EventDate,
                EventImage = x.EventImage,
                Description = x.Description,
                Venue = x.Venue
            }).ToHashSet();
            if (ets == null)
            {
                return new EventResponseModel
                {
                    Message = "No available Event",
                    Success = false
                };
            }
            return new EventResponseModel
            { 
                Success = true,
                Message = "List of Events"
            };
        }

        public async Task<EventResponseModel> GetEventByName(string Name)
        {
            var events = await _eventRepository.Get(x => x.EventName == Name);
            if (events == null)
            {
                return new EventResponseModel
                {
                    Message = "Event Name not Found",
                    Success = true
                };
            }
            var evt = new EventDTO
            {
                EventName = events.EventName,
                EventImage = events.EventImage,
                EventDate = events.EventDate,
                Venue = events.Venue,
                Description = events.Description
            };
            return new EventResponseModel
            {
                Data = evt,
                Message = "",
                Success = true
            };
        }

        public async Task<BaseResponse> UpdateEvent(UpdateEventRequestModel model, int id)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Event already existed!",
                    Success = false
                };
            }
            var events = await _eventRepository.Get(x => x.Id == id);
            if (events == null)
            {
                return new BaseResponse
                {
                    Message = "Event not found",
                    Success = false
                };
            }
            events.EventName = model.EventName;
            events.Description = model.Description;
            events.EventImage = model.Image;
            events.EventDate = model.Date;
            events.Venue = model.Venue;
            await _eventRepository.Update(events);
            return new BaseResponse
            {
                Message = "Event updated succdessfully",
                Success = true
            };
        }
    }
}