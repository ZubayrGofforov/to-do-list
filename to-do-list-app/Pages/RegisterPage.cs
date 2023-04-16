using to_do_list_app.Interfaces.Services;
using to_do_list_app.Services;
using to_do_list_app.ViewModels.Users;

namespace to_do_list_app.Pages
{
    public class RegisterPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            UserCreateViewModel userCreateView = new UserCreateViewModel();

            Console.Write("Full name: ");
            userCreateView.FullName = Console.ReadLine()!;
            Console.Write("Email: ");
            userCreateView.Email = Console.ReadLine()!;
            Console.Write("Password: ");
            userCreateView.Password = Console.ReadLine()!;

            IUserService userService = new UserService();
            var result = await userService.RegisterAsync(userCreateView);
            if (result.IsSuccessful)
            {
                Console.WriteLine("Muvaffaqqiyatli.");
                Thread.Sleep(2000);
                await LoginPage.RunAsync();
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
