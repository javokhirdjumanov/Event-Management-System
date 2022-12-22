using EventSystem.Core.EventBrokers.StorageBrokers;

namespace EventSystem.Core.EventServices;
public partial class EventServices : IEventServices
{
    /// <summary>
    /// BROKER OBJECT
    /// </summary>
    private IEventBroker brokers;
    public EventServices(IEventBroker brokers) => this.brokers = brokers;

}
