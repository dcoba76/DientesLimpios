using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;

public class ValidadorComandoActualizarConsultorio: AbstractValidator<ComandoActualizarConsultorio>
{
    public ValidadorComandoActualizarConsultorio()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El campo {PropertyNam} es obligatorio.")
            .MaximumLength(150).WithMessage("El nombre del consultorio no puede exceder los 100 caracteres.");
    }
}
