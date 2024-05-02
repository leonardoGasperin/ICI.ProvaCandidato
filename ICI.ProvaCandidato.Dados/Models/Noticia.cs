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
            return new NoticiaDto() {
                Titulo = Titulo,
                Texto = Texto,
                Usuario = Usuario.ConverterToDto()
            };
        }
    }
}
