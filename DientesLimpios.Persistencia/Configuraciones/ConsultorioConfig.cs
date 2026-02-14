using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DientesLimpios.Persistencia.Configuraciones;

public class ConsultorioConfig : IEntityTypeConfiguration<Consultorio>
{
    public void Configure(EntityTypeBuilder<Consultorio> builder)
    {
        builder.Property(c => c.Nombre)
               .IsRequired()
               .HasMaxLength(150);
    }
}
