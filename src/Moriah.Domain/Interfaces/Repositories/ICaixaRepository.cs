using Moriah.Domain.Entities;

namespace Moriah.Domain.Interfaces.Repositories;

public interface ICaixaRepository
{
    Task Insert(Caixa caixa);
    Task<List<Caixa>> GetAll();
}