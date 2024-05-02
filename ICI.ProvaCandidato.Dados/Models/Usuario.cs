using ICI.ProvaCandidato.Dados.Dto;

namespace ICI.ProvaCandidato.Dados.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email {  get; set; }

        public UsuarioDto ConverterToDto()
        {
            return new UsuarioDto()
            {
                Nome = Nome,
                Email = Email
            };
        }

        public static Usuario MountFromDto(UsuarioDto dto, string senha)
        {
            return new Usuario()
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = senha
            };
        }
    }
}
