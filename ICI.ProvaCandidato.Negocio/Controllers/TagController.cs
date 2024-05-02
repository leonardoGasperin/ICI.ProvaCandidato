using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Interface;
using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        public readonly ITagRepository _repotory;
        public readonly ITagRuleRepository _rule;

        public TagController(ITagRepository repotory, ITagRuleRepository rule)
        {
            _repotory = repotory;
            _rule = rule;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _repotory.GetAll();

            return Ok(tags);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagDto dto)
        {
            var exist = await _rule.AlreadyExist(dto.Descricao);

            try
            {
                if (!exist)
                {
                    await _repotory.Create(dto);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok(dto);
        }
    }
}
