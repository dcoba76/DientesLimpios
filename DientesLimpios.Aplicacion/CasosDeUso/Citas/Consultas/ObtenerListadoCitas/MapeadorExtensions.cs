using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;

public static class MapeadorExtensions
{
    public static CitaListadoDTO ADto(this Cita cita)
    {
        return new CitaListadoDTO
        {
            Id = cita.Id,
            Inicio = cita.IntervaloDeTiempo.Inicio,
            Fin = cita.IntervaloDeTiempo.Fin,
            Consultorio = cita.Consultorio!.Nombre,
            Paciente = cita.Paciente!.Nombre,
            Dentista = cita.Dentista!.Nombre,
            Estado = cita.Estado.ToString(),
        };
    }
}
