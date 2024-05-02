using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Interface;
using ICI.ProvaCandidato.Negocio.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Repositories
{
    public class TagRuleRepository : ITagRuleRepository
    {
        public readonly SqliteContext _context;

        public TagRuleRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExist(string descricao)
        {
            return await _context.Tags.AnyAsync(x => x.Descricao == descricao);
        }

        public async Task<bool> CannotDelete(string descricao)
        {
            if (await AlreadyExist(descricao))
            {
                var tagToDelete =  _context.Tags.FirstOrDefault(x => x.Descricao == descricao);
                var t = _context.TagNoticias.AsNoTracking().FirstOrDefault();
                return await _context.TagNoticias.AsNoTracking().AnyAsync(x => x.TagId == tagToDelete.Id);
            }
            return true;
        }
    }
}
