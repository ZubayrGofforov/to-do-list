using to_do_list_app.Interfaces.Services;
using to_do_list_app.Services;

namespace to_do_list_app.Pages
{
    public class LoginPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            IUserService userService = new UserService();
            var result = await userService.LoginAsync(email, password);
            if (result.IsSuccessful)
            {
                Console.WriteLine("Muvaffaqqiyatli");
                Thread.Sleep(1500);
                await MainPage.RunAsync();
            }
            else
            {
                Console.WriteLine(result.Message);
                Thread.Sleep(2000);
                await RunAsync();
            }
        }
    }
}
