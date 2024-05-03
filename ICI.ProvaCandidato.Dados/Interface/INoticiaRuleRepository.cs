using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Interface
{
    public interface INoticiaRuleRepository
    {
        public Task<bool> CannotDelete(int id);
        public Task<bool> NeedCreatNewAccount(string email);
        public Task<bool> NeedCreateNewTag(string descricao);
    }
}
