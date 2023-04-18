using Microsoft.EntityFrameworkCore;
using Moriah.Domain.Entities;
using Moriah.Infra.Data.Mapping;

namespace Moriah.Infra.Data.Context;

public class MoriahDataContext : DbContext
{
    public MoriahDataContext(DbContextOptions<MoriahDataContext> options) : base (options){}

    public DbSet<Caixa>? Entradas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CaixaMapping());
    }
}
