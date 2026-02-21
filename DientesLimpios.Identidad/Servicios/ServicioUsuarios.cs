using DientesLimpios.Aplicacion.Contratos.Identidad;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DientesLimpios.Identidad.Servicios;

public class ServicioUsuarios : IServicioUsuarios
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ServicioUsuarios(IHttpContextAccessor httpContextAccessor)
    {
        this._httpContextAccessor = httpContextAccessor;
    }
    public string ObtenerUsuarioId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }
}
