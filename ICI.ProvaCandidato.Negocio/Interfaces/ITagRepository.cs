using ICI.ProvaCandidato.Dados.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface ITagRepository
    {
        public Task<List<TagDto>> GetAll();
    }
}
