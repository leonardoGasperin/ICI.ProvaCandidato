using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Dto;

namespace ICI.ProvaCandidato.Dados.Interface
{
    public interface IUsuarioRuleRepository
    {
        public Task<bool> CanCreateUsuario(UsuarioDto dto);
    }
}
