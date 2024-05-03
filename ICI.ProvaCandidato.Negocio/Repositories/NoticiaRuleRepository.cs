using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Interface;
using ICI.ProvaCandidato.Negocio.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Negocio.Repositories
{
    public class NoticiaRuleRepository : INoticiaRuleRepository
    {
        public readonly SqliteContext _context;

        public NoticiaRuleRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<bool> NeedCreatNewAccount(string email)
        {
            return await _context.Usuarios.AnyAsync(x => x.Email.Equals(email));
        }

        public async Task<bool> NeedCreateNewTag(string descricao)
        {
            return await _context.Tags.AnyAsync(x => x.Descricao.Equals(descricao));
        }
    }
}
