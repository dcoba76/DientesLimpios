using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita;

public static class MapeadorExtensions
{
    public static CitaDetalleDTO ADto(this Cita cita)
    {
        return new CitaDetalleDTO
        {
            Id = cita.Id,
            Inicio = cita.IntervaloDeTiempo.Inicio,
            Fin = cita.IntervaloDeTiempo.Fin,
            Consultorio = cita.Consultorio!.Nombre,
            Dentista = cita.Dentista!.Nombre,
            Paciente = cita.Paciente!.Nombre,
            Estado = cita.Estado.ToString(),
        };
    }
}
