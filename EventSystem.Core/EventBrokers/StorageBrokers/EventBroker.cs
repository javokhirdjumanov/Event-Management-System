using EventSystem.Core.EventBrokers.Data;

namespace EventSystem.Core.EventBrokers.StorageBrokers;
public partial class EventBroker : IEventBroker
{ 
    public AppDBContext Context()
    {
        AppDBContext context = new AppDBContext();

        return context;
    }
}
