using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaRepository _repository;

        public NoticiaController(INoticiaRepository context)
        {
            _repository = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var noticias = await _repository.GetAll();
            return Ok(noticias);
        }
    }
}
