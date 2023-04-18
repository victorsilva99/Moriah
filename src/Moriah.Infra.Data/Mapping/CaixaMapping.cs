using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moriah.Domain.Entities;

namespace Moriah.Infra.Data.Mapping;

public class CaixaMapping : IEntityTypeConfiguration<Caixa>
{
    public void Configure(EntityTypeBuilder<Caixa> builder)
    {
        builder.ToTable(nameof(Caixa));

        builder.HasKey(caixa => caixa.Id);

        builder.Property(caixa => caixa.Data)
            .IsRequired()
            .HasColumnName("Data")
            .HasColumnType("date");

        builder.Property(caixa => caixa.Nota)
            .HasColumnName("Nota")
            .HasColumnType("smallmoney");

        builder.Property(caixa => caixa.Moeda)
            .HasColumnName("Moeda")
            .HasColumnType("smallmoney");

        builder.Property(caixa => caixa.Cartao)
            .HasColumnName("Cartao")
            .HasColumnType("smallmoney");

        builder.Property(caixa => caixa.CriacaoRegistro)
            .HasColumnName("Criacao_Registro")
            .HasColumnType("datetime")
            .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(caixa => caixa.UltimaAtualizacao)
            .HasColumnName("Ultima_Atualizacao")
            .HasColumnType("datetime");

        builder.HasIndex(x => x.Data, "IX_Data")
            .IsUnique();
    }
}