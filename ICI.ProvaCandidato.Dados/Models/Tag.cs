using ICI.ProvaCandidato.Dados.Dto;

namespace ICI.ProvaCandidato.Dados.Models
{
    public class Tag : Entity
    {
        public string Descricao { get; set; }

        public TagDto ConverterToDto() 
        {
            return new TagDto(){
                Descricao = Descricao,
            };
        }
    }
}
