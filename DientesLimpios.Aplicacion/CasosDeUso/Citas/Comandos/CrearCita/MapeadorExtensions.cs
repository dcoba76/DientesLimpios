
using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita;

public static class MapeadorExtensions
{
    public static ConfirmacionCitaDTO ADto(this Cita cita)
    {
        return new ConfirmacionCitaDTO
        {
            Id = cita.Id,
            Fecha   = cita.IntervaloDeTiempo.Inicio,
            Paciente = cita.Paciente?.Nombre ?? string.Empty,
            Paciente_Email = cita.Paciente?.Email.Valor ?? string.Empty,
            Consultorio = cita.Consultorio?.Nombre ?? string.Empty,
            Dentista = cita.Dentista?.Nombre ?? string.Empty
        };
    }
}
