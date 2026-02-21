using DientesLimpios.API.DTOs.Citas;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.BorrarCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CancelarCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CompletarCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers;

[ApiController]
[Route("api/citas")]
public class CitasController: ControllerBase
{
    private readonly IMediator _mediator;

    public CitasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<CitaListadoDTO>>> Get([FromQuery] ConsultaObtenerListadoCitas consulta)
    {
        var resultado = await _mediator.Send(consulta);
        return resultado;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CitaDetalleDTO>> Get(Guid id)
    {
        var consulta = new ConsultaObtenerDetalleCita { Id = id };
        var resultado = await _mediator.Send(consulta);
        return resultado;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CrearCitaDTO crearCitaDTO)
    {
        var comando = new ComandoCrearCita
        {
            PacienteId = crearCitaDTO.PacienteId,
            DentistaId = crearCitaDTO.DentistaId,
            ConsultorioId = crearCitaDTO.ConsultorioId,
            Inicio = crearCitaDTO.Inicio,
            Fin = crearCitaDTO.Fin
        };

        await _mediator.Send(comando);
        return Ok();
    }

    [HttpPut("cancelar/{id}")]
    public async Task<IActionResult> Cancelar(Guid id)
    {
        var comando = new ComandoCancelarCita { Id = id };
        await _mediator.Send(comando);
        return NoContent();
    }

    [HttpPut("completar/{id}")]
    public async Task<IActionResult> Completar(Guid id)
    {
        var comando = new ComandoCompletarCita { Id = id };
        await _mediator.Send(comando);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var comando = new ComandoBorrarCita { Id = id };
        await _mediator.Send(comando);
        return NoContent();
    }
}
