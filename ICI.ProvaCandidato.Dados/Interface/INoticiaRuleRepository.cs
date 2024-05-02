using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Interface
{
    public interface INoticiaRuleRepository
    {
        public Task<bool> CannotDelete(int id);
    }
}
