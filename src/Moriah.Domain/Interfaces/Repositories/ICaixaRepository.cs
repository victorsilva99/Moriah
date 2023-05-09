using Moriah.Domain.Entities;

namespace Moriah.Domain.Interfaces.Repositories;

public interface ICaixaRepository
{
    Task Insert(Caixa caixa);
    Task<IEnumerable<Caixa>> GetAllAsync();
    Caixa? GetById(string id);
    Caixa GetByIdEf(Guid id);
    Task<Caixa> GetByIdAsync(string id);
    Task<Caixa> GetByIdEfAsync(Guid id);
    Caixa? GetByData(DateTime data);
    Task Update(Caixa caixa);
    Task Delete(Caixa caixa);
}