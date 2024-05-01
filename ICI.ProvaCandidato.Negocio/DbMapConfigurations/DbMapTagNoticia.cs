using ICI.ProvaCandidato.Dados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICI.ProvaCandidato.Negocio.DbMapConfigurations
{
    public class DbMapTagNoticia : IEntityTypeConfiguration<TagNoticia>
    {
        public void Configure(EntityTypeBuilder<TagNoticia> builder)
        {
            builder.ToTable("TagNoticias");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NoticiaId).HasColumnType("INTERGER").IsRequired();
            builder.Property(x => x.TagId).HasColumnType("INTERGER").IsRequired();
        }
    }
}
