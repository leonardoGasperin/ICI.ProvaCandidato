using ICI.ProvaCandidato.Dados.Dto;

namespace ICI.ProvaCandidato.Dados.Models
{
    public class Noticia : Entity
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public NoticiaDto ConverterToDto()
        {
            return new NoticiaDto()
            {
                RefId = Id,
                Titulo = Titulo,
                Texto = Texto,
                UsuarioId = UsuarioId,
                Usuario = Usuario
            };
        }

        public static Noticia MountFromDto(NoticiaDto dto)
        {
            return new Noticia()
            {
                Titulo = dto.Titulo,
                Texto = dto.Texto,
                UsuarioId = dto.UsuarioId
            };
        }
    }
}
