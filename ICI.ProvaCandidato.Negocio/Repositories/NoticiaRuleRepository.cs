using ICI.ProvaCandidato.Dados.Interface;
using ICI.ProvaCandidato.Negocio.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Repositories
{
    public class NoticiaRuleRepository : INoticiaRuleRepository
    {
        public readonly SqliteContext _context;
        public NoticiaRuleRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<bool> CannotDelete(int id)
        {
            return await _context.TagNoticias.AnyAsync(x => x.Id == id);
        }
    }
}
