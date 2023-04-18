using Microsoft.EntityFrameworkCore;
using Moriah.Domain.Entities;
using Moriah.Domain.Interfaces.Repositories;
using Moriah.Infra.Data.Context;

namespace Moriah.Infra.Data.Repositories;

public class CaixaRepository : ICaixaRepository
{
    private readonly MoriahDataContext _context;

    public CaixaRepository(MoriahDataContext context)
    {
        _context = context;
    }

    public async Task Insert(Caixa caixa)
    {
        _context.Entradas?.Add(caixa);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Caixa>> GetAll()
    {
        return await _context.Entradas?.ToListAsync();
    }
}