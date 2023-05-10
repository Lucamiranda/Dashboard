using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dashboard.Model;

namespace Dashboard.Dados
{
    public class FormulasConfiguration : IEntityTypeConfiguration<Formulas>
    {
        public void Configure(EntityTypeBuilder<Formulas> builder)
        {
            builder.ToTable("FC12100");

            builder.Property(a => a.Filial)
                .HasColumnName("CDFIL")
                .HasColumnType("integer");

            builder.Property(a => a.Requisicao)
                .HasColumnName("NRRQU")
                .HasColumnType("integer");
                

            builder.Property(a => a.Serie)
                .HasColumnName("SERIER")
                .HasColumnType("CHAR(1)");

            builder.Property(a => a.ValorCobrado)
                .HasColumnName("PRCOBR")
                .HasColumnType("NUMERIC(14,2)");

            builder.Property(a => a.Desconto)
                .HasColumnName("VRDSC")
                .HasColumnType("NUMERIC(14,2)");

            builder.Property(a => a.DataEntrada)
                .HasColumnName("DTENTR")
                .HasColumnType("DATE");


        }
    }
}