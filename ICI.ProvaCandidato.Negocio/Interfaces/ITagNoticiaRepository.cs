using System.Collections.Generic;
using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Dto;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface ITagNoticiaRepository
    {
        public Task<string> GetTagByNoticiaId(int noticiaId);
        public Task<List<NoticiaDto>> GetAllByTag(string descricao);
    }
}
