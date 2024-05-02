using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Interface;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaRepository _repository;
        private readonly INoticiaRuleRepository _rule;

        public NoticiaController(INoticiaRepository context, INoticiaRuleRepository rule)
        {
            _repository = context;
            _rule = rule;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var noticias = await _repository.GetAll();
            return Ok(noticias);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoticiaDto dto)
        {
            try
            {
                await _repository.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok(dto);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit(NoticiaDto dto, int noticiaId)
        {
            try
            {
                await _repository.Update(dto, noticiaId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int noticiaId)
        {
            var cannotDelete = await _rule.CannotDelete(noticiaId);

            try
            {
                if (!cannotDelete)
                {
                    await _repository.Delete(noticiaId);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok();
        }
    }
}
