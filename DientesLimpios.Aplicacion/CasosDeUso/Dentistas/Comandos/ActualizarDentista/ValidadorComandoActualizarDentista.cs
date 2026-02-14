using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.ActualizarDentista;

public class ValidadorComandoActualizarDentista: AbstractValidator<ComandoActualizarDentista>
{
    public ValidadorComandoActualizarDentista()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
            .MaximumLength(150).WithMessage("El nombre no puede exceder los 150 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
            .EmailAddress().WithMessage("El {PropertyName} no es válido.");
    }
}
