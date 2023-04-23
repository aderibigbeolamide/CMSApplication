using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.Interfaces.Services
{
    public interface ICreateUserService
    {
        Task<BaseResponse> CreateAdmin(AddAdminRequestModel model);
        Task<BaseResponse> CreateDonor(CreateUserRequestModel model);
        Task<BaseResponse> CreateCharityHome(CreateUserRequestModel model);
        Task<CreateUserResponseModel> GetUser(string email);
        Task<BaseResponse> VerifyUser(VerifyUserRequestModel model);
    }
}
