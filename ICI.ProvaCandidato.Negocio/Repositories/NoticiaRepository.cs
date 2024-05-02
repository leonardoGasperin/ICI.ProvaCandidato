using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.DbContexts;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task Create(NoticiaDto dto, Usuario usuario, Tag tag) 
        {
            try
            {
                var newNoticia = Noticia.MountFromDto(dto);
                newNoticia.UsuarioId = usuario.Id;
                _context.Noticias.Add(newNoticia);
                await _context.SaveChangesAsync();

                var tagNoticiaRelation = new TagNoticia()
                {
                    NoticiaId = newNoticia.Id,
                    TagId = tag.Id,
                };

                _context.TagNoticias.Add(tagNoticiaRelation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao criar a notícia: {ex.Message}");

                // Se houver uma exceção interna, registre-a também
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
           
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

        public async Task<Usuario> GetUsuarioReferencia(UsuarioDto dto)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email.Equals(dto.Email));
        }

        public async Task<Tag> GetTagReferencia(TagDto dto)
        {
            return await _context.Tags
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Descricao.Equals(dto.Descricao));
        }

        public async Task<Usuario> CreateUsuarioToNoticia(UsuarioDto newUsuario)
        {
            Usuario usuario = Usuario.MountFromDto(newUsuario, "SenhaPadrão");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Tag> CreateTagToNoticia(string newTag)
        {
            Tag tag = Tag.MountFromDto(new() { Descricao = newTag });

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return tag;
        }
    }
}
