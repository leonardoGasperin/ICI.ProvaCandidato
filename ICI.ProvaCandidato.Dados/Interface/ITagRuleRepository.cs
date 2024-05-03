using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Dto;

namespace ICI.ProvaCandidato.Dados.Interface
{
    public interface ITagRuleRepository
    {
        public Task<bool> AlreadyExist(string descricao);
        public Task<bool> CannotDelete(string descricao);
    }
}
