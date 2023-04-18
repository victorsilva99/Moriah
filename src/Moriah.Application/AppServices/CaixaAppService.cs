using AutoMapper;
using Moriah.Application.Interfaces;
using Moriah.Application.ViewModels;
using Moriah.Domain.Entities;
using Moriah.Domain.Interfaces.Services;

namespace Moriah.Application.AppServices
{
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
    }
}
