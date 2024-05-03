using System.Threading.Tasks;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ICI.ProvaCandidato.Negocio.Controllers
{
    public class TagNoticiaController : ControllerBase
    {
        public readonly ITagNoticiaRepository _repository;

        public TagNoticiaController(ITagNoticiaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/TagByNoticiaId")]
        public async Task<IActionResult> GetTagByNoticiaId(int id)
        {
            var descricao = await _repository.GetTagByNoticiaId(id);

            return Ok(descricao);
        }

        [HttpGet("api/GetAllByTag")]
        public async Task<IActionResult> GetAllByTag(string descricao)
        {
            var noticias = await _repository.GetAllByTag(descricao);

            return Ok(noticias);
        }
    }
}
