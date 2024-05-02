using ICI.ProvaCandidato.Dados.Models;

namespace ICI.ProvaCandidato.Dados.Dto
{
    public class NoticiaDto
    {
        public int RefId { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; } = new();
    }
}
