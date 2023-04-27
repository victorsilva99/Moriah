using Moriah.Domain.Entities;

namespace Moriah.Domain.Interfaces.Services;

public interface ICaixaService
{
    Task Insert(Caixa caixa);
    Task<IEnumerable<Caixa>> GetAllAsync();
    Task<Caixa> GetByIdAsync(string id);
    Task<Caixa> GetByIdEFAsync(Guid id);
    Task Update(Caixa caixa);
    Task Delete(string id);
}