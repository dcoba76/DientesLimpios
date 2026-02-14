using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerListadoDentistas;

public static class MapeadorExtensions
{
    public static DentistaListadoDTO ADto(this Dentista dentista)
    {
        return new DentistaListadoDTO
        {
            Id = dentista.Id,
            Nombre = dentista.Nombre
        };
    }
}
