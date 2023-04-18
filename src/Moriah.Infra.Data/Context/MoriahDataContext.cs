using Microsoft.EntityFrameworkCore;
using Moriah.Domain.Entities;

namespace Moriah.Infra.Data.Context;

public class MoriahDataContext : DbContext
{
    public DbSet<Caixa> Entradas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("");
    }
}
