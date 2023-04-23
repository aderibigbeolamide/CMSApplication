using CMSApplication.DTOs.ResponseModel;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Repositories;
using CMSApplication.Interfaces.Services;

namespace CMSApplication.Implementations.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<BaseResponse> RegisterDocument(string model)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Value cannot be null"
                };
            }

            var doc = new Document
            {
                Path = model
            };
            await _documentRepository.Register(doc);

            return new BaseResponse
            {
                Success = true,
                Message = "New Image succussfully added"
            };
        }
    }
}
