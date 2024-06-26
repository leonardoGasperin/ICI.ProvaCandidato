﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Dto;
using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.DbContexts;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Negocio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly SqliteContext _context;

        public UsuarioRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioDto>> GetAll()
        {
            var usuarios = await _context
                .Usuarios.AsNoTracking()
                .Select(x => x.ConverterToDto())
                .ToListAsync();
            return usuarios;
        }

        public async Task Create(UsuarioDto dto, string senha)
        {
            _context.Usuarios.Add(Usuario.MountFromDto(dto, senha));
            await _context.SaveChangesAsync();
        }
    }
}
