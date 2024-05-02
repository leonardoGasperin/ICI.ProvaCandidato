using ICI.ProvaCandidato.Dados.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface INoticiaRepository
    {
        public Task<List<NoticiaDto>> GetAll();
    }
}
