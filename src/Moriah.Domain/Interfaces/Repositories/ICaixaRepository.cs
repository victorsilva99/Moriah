using Moriah.Domain.Entities;

namespace Moriah.Domain.Interfaces.Repositories;

public interface ICaixaRepository
{
    Task Insert(Caixa caixa);
    Task<IEnumerable<Caixa>> GetAllAsync();
    Task<Caixa> GetByIdAsync(string id);
    Task<Caixa> GetByIdEfAsync(Guid id);
    Task Update(Caixa caixa);
}