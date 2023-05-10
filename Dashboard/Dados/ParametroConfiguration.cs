using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dashboard.Model;

namespace Dashboard.Dados
{
    public class ParametroConfiguration : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("FC99999").HasNoKey();

            builder.Property(p => p.Argumentos)
                .HasColumnType("char(30)")
                .HasColumnName("ARGUMENTO")
                .IsRequired();

            builder.Property(p => p.SubArgumentos)
                .HasColumnType("char(10)")
                .HasColumnName("SUBARGUM")
                .IsRequired();

            builder.Property(p => p.Parametros)
                .HasColumnType("varchar(100)")
                .HasColumnName("PARAMETRO")
                .IsRequired();
        }
    }
}
