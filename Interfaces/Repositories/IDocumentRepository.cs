using CMSApp.DTOs;
using CMSApp.Entities;

namespace CMSApp.Interfaces.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<IList<DocumentDTO>> GetAllWithRequest();
        Task<IList<DocumentDTO>> GetAllWithCharityHome();
        Task<IList<DocumentDTO>> GetDocumentsByCharityHomeId(int id);
    }
}
