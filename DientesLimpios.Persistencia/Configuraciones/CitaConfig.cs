using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DientesLimpios.Persistencia.Configuraciones;

public class CitaConfig : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.Property(c => c.PacienteId).IsRequired();
        builder.Property(c => c.DentistaId).IsRequired();
        builder.Property(c => c.ConsultorioId).IsRequired();
        builder.Property(c => c.Estado).IsRequired();
        
        builder.ComplexProperty(c => c.IntervaloDeTiempo, accion =>
        {
            accion.Property(e => e.Inicio).HasColumnName("Inicio");
        });

        builder.ComplexProperty(c => c.IntervaloDeTiempo, accion =>
        {
            accion.Property(e => e.Fin).HasColumnName("Fin");
        });

    }
}
