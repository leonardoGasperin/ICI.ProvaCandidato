using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Negocio.DbContexts;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Repositories
{
    public class TagNoticiaRepository : ITagNoticiaRepository
    {
        public readonly SqliteContext _context;

        public TagNoticiaRepository(SqliteContext context)
        {
            _context = context;
        }

        public Task<NoticiaDto> GetNoticiasByTag(string descricao)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetTagByNoticiaId(int noticiaId)
        {
            var tagNoticia = await _context.TagNoticias
                .AsNoTracking()
                .Include(x => x.Tag)
                .FirstOrDefaultAsync(x => x.NoticiaId.Equals(noticiaId)) ?? null;
            if(tagNoticia == null)
            {
                return new NotFoundResult().StatusCode.ToString();
            }
            return tagNoticia.Tag.Descricao;
        }


    }
}
