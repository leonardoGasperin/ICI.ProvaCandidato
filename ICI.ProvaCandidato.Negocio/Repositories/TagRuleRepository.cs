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

        public async Task<bool> AlreadyExist(string dtoDescricao)
        {
            return await _context.Tags.AnyAsync(x => x.Descricao == dtoDescricao);
        }
    }
}
