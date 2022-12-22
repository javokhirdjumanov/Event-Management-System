using EventSystem.Core.EventBrokers.Data;
using EventSystem.Core.EventServices;
using EventSystem.Core.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace EventSystem.Core.EventViews;
public class Views
{
    /// <summary>
    /// SERVICES OBJECT
    /// </summary>
    private readonly IEventServices services; 
    public Views(IEventServices services) => this.services = services;

    /// <summary>
    /// BASE MENU
    /// </summary>
    /// <returns></returns>
    public async Task ViewAsync()
    {
        Console.Clear();
        Console.WriteLine("1. RegistrationAsync");
        Console.WriteLine("2. LoginAsync");

        string choose = Console.ReadLine();

        if(choose is "1")
            await RegistrationAsync();
        else if (choose is "2")
            await LoginAsync();
    }

    /// <summary>
    /// REGISTRATION
    /// </summary>
    /// <returns></returns>
    private async Task RegistrationAsync()
    {
        Console.Clear();

        Console.Write("Username : ");
        string username = Console.ReadLine();

        Console.Write("Password : ");
        string password = Console.ReadLine();

        if (!await services.UserExistInDBAsync(username, password))
        {
            Console.Write("Name : ");
            string name = Console.ReadLine();

            Console.WriteLine("choose the rules\n1.Admin\t\t2.User\t\t3.Company");
            int role = int.Parse(Console.ReadLine());

            await services.CreateUserToDBAysnc(new Users(name, username, password, role));

            Console.WriteLine("User successfully added to database :)\n");

            Console.Write("Press the (Enter) : ");

            ConsoleKeyInfo consoleKey = new ConsoleKeyInfo();
            if (consoleKey.Key == ConsoleKey.Enter)
                await ViewAsync();
        }
        else
        {
            Console.WriteLine("User already exists in the database :(");

            await Task.Delay(3000);
            await ViewAsync();
        }
    }

    /// <summary>
    /// LOGINS
    /// </summary>
    /// <returns></returns>
    private async Task LoginAsync()
    {
        Console.Clear();
        Roles();
        string choose = Console.ReadLine();
        switch(choose)
        {
            case "1":
                Console.Clear();
                await Admin();
                break;
            case "2":
                Console.Clear();
                await Useeer();
                break;
            case "3":
                Console.Clear();
                await Company();
                break;
        }
        void Roles()
        {
            Console.WriteLine("=".PadRight('=', (char)20));
            Console.WriteLine("                 Roles");
            Console.WriteLine("=".PadRight('=', (char)20));
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            Console.WriteLine("3. Company");
            Console.Write(">>> ");
        }
    }

    //:::::::::::::::::::::::::::::::: Admin :::::::::::::::::::::::::::::::://
    private async Task Admin()
    {
        MenuForAdmin();
        string choose = Console.ReadLine();
        switch(choose)
        {
            case "1":
                Console.Clear();
                await CreateRoomToDb();
                break;
            case "2":
                Console.Clear();
                await ReadRoomsFromDb();
                break;
            case "3":
                Console.Clear();
                await UpdateRoomsFromDb();
                break;
            case "4":
                Console.Clear();
                await DeleteRoomsFromDb();
                break;
            case "5":
                Console.Clear();
                await GetAllEventFromDbAsync();
                break;
            case "6":
                break;
            case "7":
                Console.Clear();
                await LoginAsync();
                break;
        }
        void MenuForAdmin()
        {
            Console.WriteLine("1. Create Rooms");
            Console.WriteLine("2. Read   Rooms");
            Console.WriteLine("3. Update Rooms");
            Console.WriteLine("4. Delete Rooms");
            Console.WriteLine("5. Get All Events");
            Console.WriteLine("6. Empty Rooms");
            Console.WriteLine("7. Exit");
            Console.Write(">>> ");
        }
    }
    /// <summary>
    /// Create Rooms
    /// </summary>
    private async Task CreateRoomToDb()
    {
        Console.Write("Enter the room number : ");
        int room_number = int.Parse(Console.ReadLine());
        if(!await services.RoomExistToDbAsync(room_number))
        {
            Console.Write("Room Name : ");
            string room_name = Console.ReadLine();

            await services.CreateRoomToDbAsync(new Rooms(room_name, room_number));

            Console.WriteLine("Room successfully added to database :)\n");

            Exit();
        }
        else
        {
            Console.WriteLine("Room already exists in the database :(");

            await Task.Delay(3000);
            await Admin();
        }
    }
    /// <summary>
    /// Read Rooms
    /// </summary>
    private async Task ReadRoomsFromDb()
    {
        Console.Write("Room Name : ");
        string room_name = Console.ReadLine();

        var rooms = await services.ReadRoomFromDb(room_name);

        Console.WriteLine($"" +
            $"{"Room Id".PadRight(10)}" +
            $"{"Room Name".PadRight(20)}" +
            $"{"Room Number".PadRight(10)}");

        foreach (var room in rooms)
            Console.WriteLine(room);

        Exit();
    }
    /// <summary>
    /// Update Rooms
    /// </summary>
    private async Task UpdateRoomsFromDb()
    {
        Console.Write("Enter the room id : ");
        int room_id = int.Parse(Console.ReadLine());

        Console.Write("Enter the Room Name : ");
        string room_name = Console.ReadLine();

        Console.Write("Enter the Room Number : ");
        int room_number = int.Parse(Console.ReadLine());

        await services.UpdateRoomDbAsync(room_id,room_name, room_number);

        Console.WriteLine("\nRoom information has been succefully changed :)");

        Exit();
    }
    /// <summary>
    /// Delete Rooms
    /// </summary>
    private async Task DeleteRoomsFromDb()
    {
        Console.Write("Enter the room id : ");
        int room_id = int.Parse(Console.ReadLine());

        await services.DeleteRoomDbAsync(room_id);

        Console.WriteLine("\nRoom has been succefully delete from database :)");

        Exit();
    }
    /// <summary>
    /// Get All Events
    /// </summary>
    private async Task GetAllEventFromDbAsync()
    {
        var events = await services.GetAllEventsAsync();

        Console.WriteLine("Id".PadRight(10) +
            "EventName".PadRight(20) +
            "Room".PadRight(10) +
            "Date".PadRight(20) +
            "User".PadRight(10));

        foreach (var item in events)
            Console.WriteLine(item);

        Console.Write("\nPress the (Enter) : ");

        ConsoleKeyInfo consoleKey = new ConsoleKeyInfo();
        if (consoleKey.Key == ConsoleKey.Enter)
            await Admin();

    }
    private async void Exit()
    {
        Console.Write("\nPress the (Enter) : ");

        ConsoleKeyInfo consoleKey = new ConsoleKeyInfo();
        if (consoleKey.Key == ConsoleKey.Enter)
            await Admin();
    }
    //:::::::::::::::::::::::::::::::: User :::::::::::::::::::::::::::::::://
    private async Task Useeer()
    {

    }
    //:::::::::::::::::::::::::::::::: Company ::::::::::::::::::::::::::::://
    private async Task Company()
    {

    }
}
