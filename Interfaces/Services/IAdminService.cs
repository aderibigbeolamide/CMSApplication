using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;
using CMSApplication.Entities;

namespace CMSApplication.Interfaces.Services
{
    public interface IAdminService
    {
        Task<BaseResponse> RegisterAdmin(CreateAdminRequestModel model);
        Task<BaseResponse> UpdateAdmin(UpdateAdminRequestModel model, int id);
        Task<AdminsResponseModel> GetAll();
        Task<AdminResponseModel> GetById(int id);
    }
}
