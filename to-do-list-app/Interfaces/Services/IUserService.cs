using to_do_list_app.ViewModels.Users;

namespace to_do_list_app.Interfaces.Services
{
    public interface IUserService
    {
        public Task<(bool IsSuccessful, string Message)> LoginAsync(string email, string password);

        public Task<(bool IsSuccessful, string Message)> RegisterAsync(UserCreateViewModel viewModel);
    }
}
