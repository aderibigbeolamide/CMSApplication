using Microsoft.EntityFrameworkCore;
using CMSApplication.Contexts;
using CMSApplication.DTOs;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Repositories;

namespace CMSApplication.Implementations.Repositories
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<DocumentDTO>> GetAllWithRequest()
        {
            var doc = await _context.Documents.Include(x => x.CharityHome).Include(x => x.Comment).Select(x => new DocumentDTO
            {
                Name = x.Path
            }).ToListAsync();
            return doc;
        }

        public async Task<IList<DocumentDTO>> GetAllWithCharityHome()
        {
            var doc = await _context.Documents.Include(x => x.CharityHome).Include(x => x.Comment).Select(x => new DocumentDTO
            {
                Name = x.Path,
                CharityHomeId = x.CharityHomeId,
            }).ToListAsync();
            return doc;
        }

        public async Task<IList<DocumentDTO>> GetDocumentsByCharityHomeId(int id)
        {
            var doc = await _context.Documents.Include(x => x.CharityHome).Include(x => x.Comment).Where(x => x.CharityHomeId == id).Select(d => new DocumentDTO
            {
                Name = d.Path
            }).ToListAsync();
            return doc;
        }

        public Task<IList<DocumentDTO>> GetDocumentsByChrityHomeId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
