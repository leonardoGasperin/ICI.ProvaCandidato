using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.DbContexts;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Repositories
{
    public class NoticiaRepository : INoticiaRepository
    {
        public readonly SqliteContext _context;

        public NoticiaRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<List<NoticiaDto>> GetAll()
        {
            var noticias = await _context.Noticias
                .AsNoTracking()
                .Include(x => x.Usuario)
                .Select(x => x.ConverterToDto())
                .ToListAsync();

            return noticias;
        }

        public async Task Create(NoticiaDto dto) 
        {
            _context.Noticias.Add(Noticia.MountFromDto(dto));
            await _context.SaveChangesAsync();
        }

        public async Task Update(NoticiaDto dto, int noticiaId)
        {
            var noticia = _context.Noticias.FirstOrDefault(x => x.Id.Equals(noticiaId));
            noticia.Titulo = dto.Titulo;
            noticia.Texto = dto.Texto;
            _context.Noticias.Update(noticia);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int noticiaId)
        {
            var noticiaToDelete = _context.Noticias.FirstOrDefault(x => x.Id.Equals(noticiaId));
            _context.Noticias.Remove(noticiaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
