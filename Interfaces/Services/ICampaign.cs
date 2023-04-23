using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.Interfaces.Services
{
    public interface ICampaign
    {
         Task<BaseResponse> AddCampaign(CampaignRequestModel model);
         Task<CampaignResponseModel> GetAll();
         Task<CampaignResponseModel> GetCampaignByCharityHome(string Name);
         Task<CampaignResponseModel> GetCampaignByStartDate(DateTime date);
         Task<BaseResponse> DeleteCampaign(int id);
         Task<CampaignResponseModel> GetCampaignToDisplay(DateTime date);
    }
}