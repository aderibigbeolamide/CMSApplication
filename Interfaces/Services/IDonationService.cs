using CMSApp.DTOs.RequestModel;
using CMSApp.DTOs.ResponseModel;

namespace CMSApp.Interfaces.Services
{
    public interface IDonationService
    {
        Task<BaseResponse> MakeDonation(CreateDonationRequestModel model, int donorId, int requestId);
        Task<BaseResponse> UpdateDonation(UpdateDonationRequestModel model, int id);
        Task<DonationResponseModel> GetDonationById(int id);
        Task<DonationsResponseModel> GetAll();
        Task<DonationsResponseModel> GetByDonorId(int id);
        Task<DonationsResponseModel> GetByRequestId(int id);
    }
}
