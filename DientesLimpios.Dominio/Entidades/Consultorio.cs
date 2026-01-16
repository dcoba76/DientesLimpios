using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.Entidades;

public class Consultorio
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = null!;

    public Consultorio(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ExcepcionDeReglaDeNegocio("El nombre del consultorio no puede estar vacío.");
        }
        Nombre = nombre;
        Id = Guid.CreateVersion7();
    }
}
