using System.Collections.Generic;
using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Dto;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<List<UsuarioDto>> GetAll();
        public Task Create(UsuarioDto dto, string senha);
    }
}
