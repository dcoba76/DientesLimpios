using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;

public class ValidadorComandoCrearConsultorio: AbstractValidator<ComandoCrearConsultorio>
{
    public ValidadorComandoCrearConsultorio()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El campo {PropertyNam} es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre del consultorio no puede exceder los 100 caracteres.");
    }
}
