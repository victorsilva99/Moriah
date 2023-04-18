using Moriah.Domain.Entities;
using Moriah.Domain.Interfaces.Repositories;
using Moriah.Domain.Interfaces.Services;

namespace Moriah.Domain.Services;

public class CaixaService : ICaixaService
{
    private readonly ICaixaRepository _caixaRepository;

    public CaixaService(ICaixaRepository caixaRepository)
    {
        _caixaRepository = caixaRepository;
    }

    public async Task Insert(Caixa caixa)
    {
        caixa.CriacaoRegistro = DateTime.Now;
        await _caixaRepository.Insert(caixa);
    }

    public async Task<IEnumerable<Caixa>> GetAll()
    {
        return await _caixaRepository.GetAll();
    }
}