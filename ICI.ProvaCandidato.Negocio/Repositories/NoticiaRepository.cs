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
                .Include(
                    x => 
                        x.Usuario)
                .Select(
                    x => new NoticiaDto 
                    { 
                        Titulo = x.Titulo,
                        Texto = x.Texto,
                        Usuario = x.Usuario
                    })
                .ToListAsync();

            return noticias;
        }
    }
}
