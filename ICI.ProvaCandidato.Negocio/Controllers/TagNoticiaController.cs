﻿using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
    }
}