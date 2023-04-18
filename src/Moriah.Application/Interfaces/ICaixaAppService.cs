using Moriah.Application.ViewModels;

namespace Moriah.Application.Interfaces
{
    public interface ICaixaAppService
    {
        Task Salvar(CaixaViewModel caixa);
    }
}
