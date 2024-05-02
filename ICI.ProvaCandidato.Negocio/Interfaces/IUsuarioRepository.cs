using ICI.ProvaCandidato.Dados.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<List<UsuarioDto>> GetAll();
    }
}
