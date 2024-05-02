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
        public readonly ITagRepository _repository;
        public readonly ITagRuleRepository _rule;

        public TagController(ITagRepository repotory, ITagRuleRepository rule)
        {
            _repository = repotory;
            _rule = rule;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _repository.GetAll();

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
                    await _repository.Create(dto);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok(dto);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit(string descricaoOriginal, TagDto dto)
        {
            var exist = await _rule.AlreadyExist(dto.Descricao);

            try
            {
                if (!exist)
                {
                    await _repository.Update(descricaoOriginal, dto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string descricao)
        {
            var cannotDelete = await _rule.CannotDelete(descricao);

            try
            {
                if (!cannotDelete)
                {
                    await _repository.Delete(descricao);
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
