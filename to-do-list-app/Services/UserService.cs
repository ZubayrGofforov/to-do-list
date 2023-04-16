using to_do_list_app.Common;
using to_do_list_app.Interfaces.Services;
using to_do_list_app.Repositories;
using to_do_list_app.Security;
using to_do_list_app.ViewModels.Users;
using ToDoListApp.Interfaces.Repositories;
using ToDoListApp.Models;

namespace to_do_list_app.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public async Task<(bool IsSuccessful, string Message)> LoginAsync(string email, string password)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            if (user is null) return (IsSuccessful: false, Message: "Email is wrong!");

            var hashResult = PasswordHasher.Verify(password, user.Salt, user.PasswordHash);
            if (hashResult)
            {
                IdentitySingelton.BuildInstance(user.Id);
                return (IsSuccessful: true, Message: "");
            }
            else return (IsSuccessful: false, Message: "Password is wrong!");
        }

        public async Task<(bool IsSuccessful, string Message)> RegisterAsync(UserCreateViewModel viewModel)
        {
            var hashResult = PasswordHasher.Hash(viewModel.Password);
            User user = new User()
            {
                Email = viewModel.Email,
                FullName = viewModel.FullName,
                PasswordHash = hashResult.PasswordHash,
                Salt = hashResult.Salt
            };

            var result = await _userRepository.CreateAsync(user);
            if (result) return (IsSuccessful: true, Message: "");
            else return (IsSuccessful: false, Message: "User can not created!");
        }
    }
}
