using ICI.ProvaCandidato.Dados.Dto;

namespace ICI.ProvaCandidato.Negocio.Requests
{
    public class CreateNoticiaRequest
    {
        public NoticiaDto Noticia { get; set; }
        public UsuarioDto Usuario { get; set; }
        public TagDto Tag { get; set; }
    }
}
