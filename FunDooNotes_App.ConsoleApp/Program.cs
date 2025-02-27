using System;
using System.Threading.Tasks;
using FunDooNotes_App.BLL.Services;
using FunDooNotes_App.DAL.Entities;
using FunDooNotes_App.DAL.Repositories; // ✅ Ensure this is included

class Program
{
    public static async Task Main(string[] args)
    {
        // Dummy Repository instance
        IUserRepository userRepository = new UserRepositoryDummy();

        // UserService ka instance banao
        UserService userService = new UserService(userRepository);

        // Register a user
        User newUser = new User { Username = "zaid", Email = "zaid@example.com" };
        User registeredUser = await userService.RegisterAsync(newUser, "password123");
        Console.WriteLine($"User Registered: {registeredUser.Username}");

        // Login test
        User? loggedInUser = await userService.LoginAsync("zaid", "password123");
        if (loggedInUser != null)
            Console.WriteLine($"Login Successful: {loggedInUser.Username}");
        else
            Console.WriteLine("Invalid credentials");
    }
}
