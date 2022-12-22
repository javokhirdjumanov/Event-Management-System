namespace EventSystem.Core.EventBrokers.StorageBrokers;
public partial interface IEventBroker
{
    public Task<IList<Models.Events>> GetAllEventsAsync();
}
