using AutoMapper;
using Moriah.Application.Interfaces;
using Moriah.Application.ViewModels;
using Moriah.Domain.Entities;
using Moriah.Domain.Interfaces.Services;

namespace Moriah.Application.AppServices;

public class CaixaAppService : ICaixaAppService
{
    private readonly IMapper _mapper;
    private readonly ICaixaService _caixaService;

    public CaixaAppService(IMapper mapper, ICaixaService caixaService)
    {
        _mapper = mapper;
        _caixaService = caixaService;
    }

    public async Task Salvar(CaixaViewModel caixa)
    {
        var map = _mapper.Map<Caixa>(caixa);
        await _caixaService.Insert(map);
    }

    public async Task<IEnumerable<CaixaViewModel>> ObterTodosAsync()
    {
        var registros = await _caixaService.GetAllAsync();
        var map = _mapper.Map<IEnumerable<Caixa>, IEnumerable<CaixaViewModel>>(registros);

        return map;
    }

    public async Task<CaixaViewModel> ObterPorIdAsync(string id)
    {
        var registro = await _caixaService.GetByIdAsync(id);
        var map = _mapper.Map<Caixa, CaixaViewModel>(registro);

        return map;
    }

    public async Task AtualizarRegistro(CaixaViewModel model)
    {
        var registroAtual = await _caixaService.GetByIdEFAsync(model.Id);
            
        registroAtual.Nota = model.Nota;
        registroAtual.Cartao = model.Cartao;
        registroAtual.Moeda = model.Moeda;
        registroAtual.UltimaAtualizacao = DateTime.Now;
            
        await _caixaService.Update(registroAtual);
    }
}