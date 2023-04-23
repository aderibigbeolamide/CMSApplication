using CMSApplication.DTOs;
using CMSApplication.Entities;

namespace CMSApplication.Interfaces.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<IList<DocumentDTO>> GetAllWithRequest();
        Task<IList<DocumentDTO>> GetAllWithCharityHome();
        Task<IList<DocumentDTO>> GetDocumentsByCharityHomeId(int id);
    }
}
