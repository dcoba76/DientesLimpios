using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.EnviarRecordatorioCita;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System.Runtime.CompilerServices;

namespace DientesLimpios.API.Jobs
{
    public class RecordatorioCitaJob : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

        public RecordatorioCitaJob(IServiceScopeFactory serviceScopeFactory)
        {
            this._serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var ahora = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zone);
                if(ahora.Hour == 8)
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    await mediator.Send(new ComandoEnviarRecordatorioCita());
                }
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
