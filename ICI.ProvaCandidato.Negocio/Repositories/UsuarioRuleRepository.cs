using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Interface;
using ICI.ProvaCandidato.Negocio.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Repositories
{
    public class UsuarioRuleRepository : IUsuarioRuleRepository
    {
        public readonly SqliteContext _context;

        public UsuarioRuleRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<bool> CanCreateUsuario(UsuarioDto dto)
        {
            return await _context.Usuarios.AnyAsync(x => x.Email.Equals(dto.Email));
        }
    }
}
