using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dashboard.Model;

namespace Dashboard.Dados
{
    internal class ReceitasConfiguration : IEntityTypeConfiguration<Receitas>
    {
        public void Configure(EntityTypeBuilder<Receitas> builder)
        {
            builder.ToTable("FC12000");

            builder.Property(a => a.Filial)
                .HasColumnName("CDFIL")
                .HasColumnType("integer");

            builder.Property(r => r.Cliente)
                .HasColumnName("CDCLI")
                .HasColumnType("integer");

            builder.Property(r => r.Requisicao)
                .HasColumnName("NRRQU")
                .HasColumnType("integer");

            builder.Property(r => r.CanalCaptacao)
                .HasColumnName("CDCAPTACAO")
                .HasColumnType("CHAR(5)");
        }
    }
}