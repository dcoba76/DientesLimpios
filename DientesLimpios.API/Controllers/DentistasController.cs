using DientesLimpios.API.DTOs.Dentistas;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.ActualizarDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.BorrarDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.CrearDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerDetalleDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerListadoDentistas;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers;

[ApiController]
[Route("api/dentistas")]
public class DentistasController: ControllerBase
{
    private readonly IMediator _mediator;

    public DentistasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<DentistaListadoDTO>>> Get()
    {
        var consulta = new ConsultaObtenerListadoDentistas();
        var resultado = await _mediator.Send(consulta);
        return resultado;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DentistaDetalleDTO>> Get(Guid id)
    {
        var consulta = new ConsultaObtenerDetalleDentista { Id = id };
        var resultado = await _mediator.Send(consulta);
        return resultado;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CrearDentistaDTO crearDentistaDTO)
    {
        var comando = new ComandoCrearDentista
        {
            Nombre = crearDentistaDTO.Nombre,
            Email = crearDentistaDTO.Email
        };

        await _mediator.Send(comando);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, ActualizarDentistaDTO actualizarDentistaDTO)
    {
        var comando = new ComandoActualizarDentista
        {
            Id = id,
            Nombre = actualizarDentistaDTO.Nombre,
            Email = actualizarDentistaDTO.Email
        };

        await _mediator.Send(comando);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var comando = new ComandoBorrarDentista { Id = id };

        await _mediator.Send(comando);
        return NoContent();
    }
}
