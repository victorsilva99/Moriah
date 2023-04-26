using Moriah.Application.ViewModels;

namespace Moriah.Application.Interfaces
{
    public interface ICaixaAppService
    {
        Task Salvar(CaixaViewModel caixa);
        Task<IEnumerable<CaixaViewModel>> ObterTodosAsync();
        Task<CaixaViewModel> ObterPorIdAsync(string id); 
        Task AtualizarRegistro(CaixaViewModel model);
    }
}
