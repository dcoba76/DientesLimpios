using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.ActualizarPaciente;

public class ValidadorComandoActualizarPaciente: AbstractValidator<ComandoActualizarPaciente>
{
    public ValidadorComandoActualizarPaciente()
    {
        RuleFor(x => x.Nombre)
          .NotEmpty().WithMessage("El campo {PropertyNam} es obligatorio.")
          .MaximumLength(250).WithMessage("El nombre del paciente no puede exceder los 250 caracteres.");

        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("El campo {PropertyNam} es obligatorio.")
           .MaximumLength(254).WithMessage("El email no puede exceder los 254 caracteres.")
           .EmailAddress().WithMessage("El email proporcionado no es válido.");
    }
}
