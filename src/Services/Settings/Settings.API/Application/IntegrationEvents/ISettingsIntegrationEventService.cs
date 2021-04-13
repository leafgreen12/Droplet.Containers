using System;
using System.Threading.Tasks;
using EventBus.Events;

namespace Settings.API.Application.IntegrationEvents
{
    public interface ISettingsIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);

        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}