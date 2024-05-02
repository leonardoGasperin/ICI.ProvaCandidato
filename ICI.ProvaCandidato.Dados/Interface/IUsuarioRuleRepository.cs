using ICI.ProvaCandidato.Dados.Dto;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Interface
{
    public interface IUsuarioRuleRepository
    {
        public Task<bool> CanCreateUsuario(UsuarioDto dto);
    }
}
