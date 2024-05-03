using ICI.ProvaCandidato.Dados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICI.ProvaCandidato.Negocio.DbMapConfigurations
{
    public class DbMapTag : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
