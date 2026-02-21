using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace DientesLimpios.Infraestructura.Notificaciones;

public class ServicioCorreos : IServicioNotificaciones
{
    private readonly IConfiguration _configuration;

    public ServicioCorreos(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
    public async Task EnviarConfirmacionCita(ConfirmacionCitaDTO cita)
    {
        var asunto = "Configuracion de cita - Dientes Limpios";
        var cuerpo = $"Hola {cita.Paciente},\n\n" +
                     $"Tu cita con el dentista {cita.Dentista} en el consultorio {cita.Consultorio} ha sido confirmada para el día {cita.Fecha:dd/MM/yyyy} a las {cita.Fecha:HH:mm}.\n\n" +
                     "¡Gracias por elegir Dientes Limpios!";    

        await EnviarMensaje(cita.Paciente_Email, asunto, cuerpo);
    }

    public async Task EnviarRecordatorioCita(RecordatorioCitaDTO cita)
    {
        var asunto = "Recordatorio de cita - Dientes Limpios";
        var cuerpo = $"Hola {cita.Paciente},\n\n" +
                     $"Tu cita con el dentista {cita.Dentista} en el consultorio {cita.Consultorio} ha sido confirmada para el día {cita.Fecha:dd/MM/yyyy} a las {cita.Fecha:HH:mm}.\n\n" +
                     "¡Gracias por elegir Dientes Limpios!";

        await EnviarMensaje(cita.Paciente_Email, asunto, cuerpo);
    }

    private async Task EnviarMensaje(string emailDestinatario, string asunto, string cuerpo)
    {
        var nuestroEmail = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
        var password = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
        var host = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
        var puerto = _configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

        var smtpCliente = new SmtpClient(host, puerto);
        smtpCliente.EnableSsl = true;
        smtpCliente.UseDefaultCredentials = false;
        smtpCliente.Credentials = new NetworkCredential(nuestroEmail, password);

        var mensaje = new MailMessage(nuestroEmail!, emailDestinatario, asunto, cuerpo);
        await smtpCliente.SendMailAsync(mensaje);
    }

}
