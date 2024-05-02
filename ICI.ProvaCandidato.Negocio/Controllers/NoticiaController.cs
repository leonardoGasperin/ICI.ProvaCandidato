using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaRepository repository;

        public NoticiaController(INoticiaRepository context)
        {
            repository = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var news = await repository.GetAll();
            return Ok(news);
        }
    }
}
