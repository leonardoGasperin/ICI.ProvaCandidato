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
    public class TagNoticiaRepository : ITagNoticiaRepository
    {
        public readonly SqliteContext _context;

        public TagNoticiaRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<List<NoticiaDto>> GetAllByTag(string descricao)
        {
            var noticias = await _context
                .TagNoticias.Include(x => x.Noticia)
                .ThenInclude(noticia => noticia.Usuario)
                .Include(x => x.Tag)
                .AsNoTracking()
                .Where(x => x.Tag.Descricao.Equals(descricao))
                .Select(x => x.Noticia.ConverterToDto())
                .ToListAsync();

            return noticias;
        }

        public async Task<string> GetTagByNoticiaId(int noticiaId)
        {
            var tagNoticia =
                await _context
                    .TagNoticias.AsNoTracking()
                    .Include(x => x.Tag)
                    .FirstOrDefaultAsync(x => x.NoticiaId.Equals(noticiaId)) ?? null;
            if (tagNoticia == null)
            {
                return new NotFoundResult().StatusCode.ToString();
            }
            return tagNoticia.Tag.Descricao;
        }
    }
}
