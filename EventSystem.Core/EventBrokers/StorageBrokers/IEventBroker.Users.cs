using EventSystem.Core.Models;

namespace EventSystem.Core.EventBrokers.StorageBrokers;
public partial interface IEventBroker
{
    public Task CreateUserToDBAysnc(Users users);
    public Task<bool> UserExistInDBAsync(string username, string password);
}
