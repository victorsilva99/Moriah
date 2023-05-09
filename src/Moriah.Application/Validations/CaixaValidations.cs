using FluentValidation;
using Moriah.Application.ViewModels;
using Moriah.Domain.Interfaces.Repositories;

namespace Moriah.Application.Validations;

public class CaixaValidations : AbstractValidator<CaixaViewModel>
{
    private readonly ICaixaRepository _caixaRepository;

    public CaixaValidations(ICaixaRepository caixaRepository)
    {
        _caixaRepository = caixaRepository;

        When(viewModel => viewModel == null, () => { RuleFor(viewModel => viewModel).NotNull(); }).Otherwise(() =>
        {
            RuleFor(viewModel => viewModel.Data).NotNull().NotEmpty().WithMessage("A data do registro deve ser informada!");
            RuleFor(viewModel => viewModel.Data).NotEmpty().Must((model, data) => BeUnique(data)).WithMessage("Já existe um registro com a data informada");
        });
    }

    private bool BeUnique(DateTime data)
        => _caixaRepository.GetByData(data) == null;
}