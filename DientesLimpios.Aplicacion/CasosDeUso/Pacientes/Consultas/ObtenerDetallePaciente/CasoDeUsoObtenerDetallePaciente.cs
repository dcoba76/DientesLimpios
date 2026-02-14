
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerDetallePaciente;

public class CasoDeUsoObtenerDetallePaciente : IRequestHandler<ConsultaObtenerDetallePaciente, PacienteDetalleDTO>
{
    private readonly IRepositorioPacientes _repositorioPacientes;

    public CasoDeUsoObtenerDetallePaciente(IRepositorioPacientes repositorioPacientes)
    {
        this._repositorioPacientes = repositorioPacientes;
    }
    public async Task<PacienteDetalleDTO> Handle(ConsultaObtenerDetallePaciente request)
    {
        var paciente = await _repositorioPacientes.ObtenerPorId(request.Id);
        if(paciente is null)
        {
            throw new ExcepcionNoEncontrado();
        }
        return paciente.ADto();
    }
}
