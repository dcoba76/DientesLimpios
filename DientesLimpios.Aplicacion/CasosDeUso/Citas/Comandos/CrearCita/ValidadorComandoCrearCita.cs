using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita
{
    public class ValidadorComandoCrearCita: AbstractValidator<ComandoCrearCita>
    {
        public ValidadorComandoCrearCita()
        {
            RuleFor(x => x.Inicio)
                .GreaterThan(x => x.Fin).WithMessage("La fecha fin de ser posterios a la fecha de inicio")
                .GreaterThan(DateTime.UtcNow).WithMessage("La fecha inicio no puede estar en el pasado");
            RuleFor(x => x.Fin)
                .GreaterThan(DateTime.UtcNow).WithMessage("La fecha fin no puede estar en el pasado");
        }
    }
}
