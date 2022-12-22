using Microsoft.EntityFrameworkCore;

namespace EventSystem.Core.EventBrokers.StorageBrokers;
public partial class EventBroker
{
    //:::::::::::::::::::::::::::: BROKER SECTION :::::::::::::::::::::::::::://

    /// </summary>
    /// Get All Events
    /// </summary>
    public async Task<IList<Models.Events>> GetAllEventsAsync()
    {
        var events = await Context().Events.ToListAsync();

        return events;
    }
}
