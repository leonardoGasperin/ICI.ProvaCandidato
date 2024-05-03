using System;
using System.Linq;
using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Interface;
using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.Interfaces;
using ICI.ProvaCandidato.Negocio.Requests;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(CreateNoticiaRequest dto)
        {
            try
            {
                var needCrateUsuario = await _rule.NeedCreatNewAccount(dto.Usuario.Email);
                var needCrateTag = await _rule.NeedCreateNewTag(dto.Tag.Descricao);
                var usuario = new Usuario();
                var tag = new Tag();

                if (!needCrateUsuario)
                {
                    usuario = await _repository.CreateUsuarioToNoticia(dto.Usuario);
                }
                else
                {
                    usuario = await _repository.GetUsuarioReferencia(dto.Usuario);
                }
                if (!needCrateTag)
                {
                    tag = await _repository.CreateTagToNoticia(dto.Tag.Descricao);
                }
                else
                {
                    tag = await _repository.GetTagReferencia(dto.Tag);
                }

                await _repository.Create(dto.Noticia, usuario, tag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok(dto);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit(CreateNoticiaRequest dto)
        {
            try
            {
                await _repository.Update(dto);
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
            try
            {
                await _repository.Delete(noticiaId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok();
        }
    }
}
