using CMSApp.DTOs.ResponseModel;

namespace CMSApp.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<BaseResponse> RegisterDocument(string model);
    }
}
