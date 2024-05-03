using ICI.ProvaCandidato.Dados.Models;
using ICI.ProvaCandidato.Negocio.DbMapConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Negocio.DbContexts
{
    public class SqliteContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Noticia> Noticias { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<TagNoticia> TagNoticias { get; set; } = null!;

        public SqliteContext(DbContextOptions<SqliteContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DbMapUsuario());
            modelBuilder.ApplyConfiguration(new DbMapNoticia());
            modelBuilder.ApplyConfiguration(new DbMapTag());
            modelBuilder.ApplyConfiguration(new DbMapTagNoticia());
        }
    }
}
