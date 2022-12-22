using EventSystem.Core.Models;

namespace EventSystem.Core.EventServices;
public partial interface IEventServices
{
    public Task CreateUserToDBAysnc(Users users);
    public Task<bool> UserExistInDBAsync(string username, string password);
}
