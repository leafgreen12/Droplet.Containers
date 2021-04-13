using System;
using Microsoft.Azure.ServiceBus;

namespace EventBusServiceBus
{
    public interface IServiceBusPersisterConnection : IDisposable
    {
        ITopicClient TopicClient { get; }
        ISubscriptionClient SubscriptionClient { get; }
    }
}