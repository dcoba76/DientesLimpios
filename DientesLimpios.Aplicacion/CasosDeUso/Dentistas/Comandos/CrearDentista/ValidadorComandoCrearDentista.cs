using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.CrearDentista;

public class ValidadorComandoCrearDentista: AbstractValidator<ComandoCrearDentista>
{
    public ValidadorComandoCrearDentista()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
            .MaximumLength(150).WithMessage("El nombre no puede exceder los 150 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
            .EmailAddress().WithMessage("El {PropertyName} no es válido.");
    }
}
