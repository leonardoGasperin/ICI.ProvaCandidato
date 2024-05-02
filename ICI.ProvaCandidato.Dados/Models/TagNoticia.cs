namespace ICI.ProvaCandidato.Dados.Models
{
    public class TagNoticia : Entity
    {
        public int NoticiaId { get; set; }
        public virtual Noticia Noticia { get; set;}
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
