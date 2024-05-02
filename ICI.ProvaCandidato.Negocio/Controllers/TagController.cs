using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        public readonly ITagRepository _repotory;

        public TagController(ITagRepository repotory)
        {
            _repotory = repotory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _repotory.GetAll();

            return Ok(tags);
        }
    }
}
