using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.DbContexts;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .Tags
                .AsNoTracking()
                .Select(x=>x.ConverterToDto())
                .ToListAsync();

            return tags;
        }

        public async Task Create(TagDto dto)
        {
            _context.Tags.Add(Tag.Mount(dto));
            await _context.SaveChangesAsync();
        }
    }
}
