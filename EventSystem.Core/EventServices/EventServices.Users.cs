using EventSystem.Core.EventBrokers.StorageBrokers;
using EventSystem.Core.Models;

namespace EventSystem.Core.EventServices;
public partial class EventServices
{
    //:::::::::::::::::::::::::::: SERVICES SECTION :::::::::::::::::::::::::::://

    /// </summary>
    /// Funcsion for Create User to Database
    /// </summary>
    public async Task CreateUserToDBAysnc(Users users) 
        => await brokers.CreateUserToDBAysnc(users);

    /// </summary>
    /// Funcsion for Exist User In Database
    /// </summary>
    public async Task<bool> UserExistInDBAsync(string username, string password)
        => await brokers.UserExistInDBAsync(username, password);
}

