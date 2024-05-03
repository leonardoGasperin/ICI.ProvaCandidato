using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.DbContexts;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Negocio.Repositories
{
    public class TagRepository : ITagRepository
    {
        public readonly SqliteContext _context;

        public TagRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<List<TagDto>> GetAll()
        {
            var tags = await _context
                .Tags.AsNoTracking()
                .Select(x => x.ConverterToDto())
                .ToListAsync();

            return tags;
        }

        public async Task Create(TagDto dto)
        {
            _context.Tags.Add(Tag.MountFromDto(dto));
            await _context.SaveChangesAsync();
        }

        public async Task Update(string descricaoOriginal, TagDto dto)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Descricao == descricaoOriginal);
            tag.Descricao = dto.Descricao;
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string descricao)
        {
            var tagToDelete = _context.Tags.FirstOrDefault(x => x.Descricao.Equals(descricao));
            _context.Tags.Remove(tagToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
