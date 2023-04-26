using Dapper;
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
    
    public async Task<IEnumerable<Caixa>> GetAllAsync()
    {
        const string query = $@"SELECT 
                                     [Id]       AS {nameof(Caixa.Id)},
                                     [Data]     AS {nameof(Caixa.Data)},
                                     [Nota]     AS {nameof(Caixa.Nota)},
                                     [Moeda]    AS {nameof(Caixa.Moeda)},
                                     [Cartao]   AS {nameof(Caixa.Cartao)}
                                FROM 
                                    Caixa 
                                ORDER BY [Data] DESC";
        
        return await _context.Database.GetDbConnection().QueryAsync<Caixa>(query);
    }

    public async Task<Caixa> GetByIdAsync(string id)
    {
        const string query = $@"SELECT 
                                     [Id]       AS {nameof(Caixa.Id)},
                                     [Data]     AS {nameof(Caixa.Data)},
                                     [Nota]     AS {nameof(Caixa.Nota)},
                                     [Moeda]    AS {nameof(Caixa.Moeda)},
                                     [Cartao]   AS {nameof(Caixa.Cartao)}
                                FROM 
                                    Caixa 
                                WHERE 
                                    [Id] = @id";
        
        return await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<Caixa>(query, new {id});
    }

    public async Task<Caixa> GetByIdEfAsync(Guid id)
    {
        return await _context.Entradas.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task Update(Caixa caixa)
    {
        _context.Entradas?.Update(caixa);
        await _context.SaveChangesAsync();
    }
}