using Moriah.Domain.Entities;

namespace Moriah.Domain.Interfaces.Services;

public interface ICaixaService
{
    Task Insert(Caixa caixa);
    Task<IEnumerable<Caixa>> GetAll();
}