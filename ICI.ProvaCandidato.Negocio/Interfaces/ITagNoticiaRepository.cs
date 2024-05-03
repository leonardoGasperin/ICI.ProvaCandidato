using ICI.ProvaCandidato.Dados.Dto;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface ITagNoticiaRepository
    {
        public Task<string> GetTagByNoticiaId(int noticiaId);
        public Task<NoticiaDto> GetNoticiasByTag(string descricao);
    }
}
