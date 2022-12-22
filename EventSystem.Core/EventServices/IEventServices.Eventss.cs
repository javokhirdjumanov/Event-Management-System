namespace EventSystem.Core.EventServices;
public partial interface IEventServices
{
    public Task<IList<Models.Events>> GetAllEventsAsync();
}
