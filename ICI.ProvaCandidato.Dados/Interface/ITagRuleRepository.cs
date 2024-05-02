using ICI.ProvaCandidato.Dados.Dto;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Interface
{
    public interface ITagRuleRepository
    {
        public Task<bool> AlreadyExist(string descricao);
        public Task<bool> CannotDelete(string descricao);
    }
}
