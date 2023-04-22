using CMSApp.DTOs.RequestModel;
using CMSApp.DTOs.ResponseModel;

namespace CMSApp.Interfaces.Services
{
    public interface ICharityHomeService
    {
        Task<BaseResponse> Register(CreateCharityHomeRequestModel model);
        Task<BaseResponse> Update(UpdateCharityHomeRequestModel model, int id);
        Task<CharityHomesResponseModel> GetAll();
        Task<CharityHomesResponseModel> GetAllWithCategory();
        Task<int> GetAllCount();
        Task<CharityHomesResponseModel> GetBannedCharityHomes();
        Task<CharityHomeResponseModel> GetCharityHome(int id);
        Task<CharityHomeResponseModel> GetCharityHomeByEmail(string email);
        Task<CharityHomesResponseModel> GetCharityHomeByName(string name);
        Task<CharityHomesResponseModel> GetByDescriptionContent(string content);
        Task<CharityHomesResponseModel> GetUnapprovedCharityHomes();
        Task<int> GetUnapprovedCharityHomesCount();
        Task<BaseResponse> UploadDocuments(UploadRequestModel model, int charityHomeId);
        Task<BaseResponse> ApproveCharityHome(int id);
        Task<BaseResponse> BanCharityHome(int id);
        Task<BaseResponse> UnbanCharityHome(int id);
        Task<BaseResponse> DeleteCharityHome(int id);
        Task<BaseResponse> UpdateBankDetails(AccountDetailsRequestModel model, int id);
        Task<BaseResponse> UpdateAddress(AddressRequestModel model, int id);
    }
}
