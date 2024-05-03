using System.Collections.Generic;
using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.Requests;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface INoticiaRepository
    {
        public Task<List<NoticiaDto>> GetAll();
        public Task Create(NoticiaDto dto, Usuario usuario, Tag tag);
        public Task Update(CreateNoticiaRequest dto);
        public Task Delete(int noticiaId);
        public Task<Usuario> GetUsuarioReferencia(UsuarioDto dto);
        public Task<Usuario> CreateUsuarioToNoticia(UsuarioDto newUsuario);
        public Task<Tag> CreateTagToNoticia(string newTag);
        public Task<Tag> GetTagReferencia(TagDto dto);
    }
}
