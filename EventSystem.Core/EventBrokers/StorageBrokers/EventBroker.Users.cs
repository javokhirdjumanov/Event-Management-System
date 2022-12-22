using EventSystem.Core.EventBrokers.Data;
using EventSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EventSystem.Core.EventBrokers.StorageBrokers;
public partial class EventBroker
{
    //:::::::::::::::::::::::::::: BROKER SECTION :::::::::::::::::::::::::::://

    // </summary>
    /// Funcsion for Exist User In Database
    /// </summary>
    public async Task<bool> UserExistInDBAsync(string username, string password)
    {
        var context = Context();

        bool exist = await context.Users
            .AnyAsync(user => user.Username == username && user.Password == password);

        return exist;
    }

    /// </summary>
    /// Funcsion for Create User to Database
    /// </summary>
    public async Task CreateUserToDBAysnc(Users users)
    {
        var context = Context();

        await context.Users.AddAsync(users);
        await context.SaveChangesAsync();
    }
}
