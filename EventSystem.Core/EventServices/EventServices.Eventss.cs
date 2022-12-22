namespace EventSystem.Core.EventServices;
public partial class EventServices
{
    //:::::::::::::::::::::::::::: SERVICES SECTION :::::::::::::::::::::::::::://

    /// </summary>
    /// Get All Events From Database
    /// </summary>
    public async Task<IList<Models.Events>> GetAllEventsAsync()
        => await brokers.GetAllEventsAsync();

}
