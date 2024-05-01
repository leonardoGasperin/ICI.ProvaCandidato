namespace ICI.ProvaCandidato.Dados.Models
{
    public class TagNoticia : Entity
    {
        public int NoticiaId { get; set; }
        public Noticia Noticia { get; set;}
        public int TagId { get; set; }
        public int Tag { get; set; }
    }
}
