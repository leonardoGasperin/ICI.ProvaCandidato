using ICI.ProvaCandidato.Dados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICI.ProvaCandidato.Negocio.DbMapConfigurations
{
    public class DbMapNoticia : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.ToTable("Noticias");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Texto).HasColumnType("TEXT").IsRequired();
        }
    }
}
