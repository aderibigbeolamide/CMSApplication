using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.Interfaces.Services
{
    public interface IVolunteer
    {
         Task<BaseResponse> AddVolunteer(VolunteerRequestModel model);
         Task<BaseResponse> UpdateVolunteer(UpdateVolunteerRequestModel model, int id);
         Task<BaseResponse> DeleteVolunteer(int id);
         Task<VolunteerResponseModel> GetVolunteerByVoluntryName(string voluntryName);
    }
}