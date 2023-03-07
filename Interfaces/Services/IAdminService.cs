using CMSApp.DTOs.RequestModel;
using CMSApp.DTOs.ResponseModel;
using CMSApp.Entities;

namespace CMSApp.Interfaces.Services
{
    public interface IAdminService
    {
        Task<BaseResponse> RegisterAdmin(CreateAdminRequestModel model);
        Task<BaseResponse> UpdateAdmin(UpdateAdminRequestModel model, int id);
        Task<AdminsResponseModel> GetAll();
        Task<AdminResponseModel> GetById(int id);
    }
}
