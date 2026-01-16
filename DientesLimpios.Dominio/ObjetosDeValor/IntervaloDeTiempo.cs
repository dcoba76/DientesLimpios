using DientesLimpios.Dominio.Excepciones;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DientesLimpios.Dominio.ObjetosDeValor;

public record IntervaloDeTiempo
{
    public DateTime Inicio { get; }
    public DateTime Fin { get; }
    public IntervaloDeTiempo(DateTime inicio, DateTime fin)
    {
        if(inicio>= fin)
        {
            throw new ExcepcionDeReglaDeNegocio($"La hora y fecha de inicio debe ser anterior a la fecha y hora fin");
        }
        Inicio = inicio;
        Fin = fin;
    }
}
