using EventSystem.Core.EventBrokers.StorageBrokers;
namespace EventSystem.Core;
public class Program
{
    public static async Task Main(string[] args)
    {
        await BaseAsync();
    }
    public static async Task BaseAsync()
    {
        Console.Clear();
        var brokers = new EventBroker();
        var services = new EventServices.EventServices(brokers);
        var views = new EventViews.Views(services);

        await views.ViewAsync();
    }
}