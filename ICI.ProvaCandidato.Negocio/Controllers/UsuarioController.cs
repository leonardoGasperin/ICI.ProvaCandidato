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
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _repository;
        public readonly IUsuarioRuleRepository _rule;

        public UsuarioController(IUsuarioRepository repository, IUsuarioRuleRepository rule)
        {
            _repository = repository;
            _rule = rule;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _repository.GetAll();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioDto dto, string senha)
        {
            var cannotCreate = await _rule.CanCreateUsuario(dto);

            try
            {
                if (!cannotCreate)
                {
                    await _repository.Create(dto, senha);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(dto);
        }
    }
}
