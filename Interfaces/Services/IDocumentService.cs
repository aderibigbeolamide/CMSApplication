using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<BaseResponse> RegisterDocument(string model);
    }
}
