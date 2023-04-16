using to_do_list_app.Interfaces.Repositories;
using to_do_list_app.Pages.Tasks;
using to_do_list_app.Repositories;

namespace to_do_list_app.Pages
{
    public class GetPage
    {
        public static async Task RunAsync()
        {
            await GetAllPage.RunAsync();
            Console.Write("Task id'sini kiriting: ");
            long id = long.Parse(Console.ReadLine());
            ITaskRepository taskRepository = new TaskRepository();
            var task = await taskRepository.FindByIdAsync(id);

            Console.WriteLine($"Id: {task.Id}");
            Console.WriteLine($"Nomi: {task.Title}");
            Console.WriteLine($"Batafsil: {task.Description}");
            Console.WriteLine($"Boshlangan vaqti: {task.BeginTime}");
            Console.WriteLine($"Tugash vaqti: {task.EndTime}");
            Console.WriteLine($"Vazifa berilgan vaqti: {task.CreatedAt}");
            Console.WriteLine($"Holati: {task.Status}");
        }
    }
}
