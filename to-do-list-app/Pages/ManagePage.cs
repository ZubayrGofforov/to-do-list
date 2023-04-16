using to_do_list_app.Interfaces.Repositories;
using to_do_list_app.Pages.Tasks;
using to_do_list_app.Repositories;

namespace to_do_list_app.Pages
{
    public class ManagePage
    {
        public static async Task RunAsync()
        {
            await GetAllPage.RunAsync();
            Console.Write("Task id'isini kiriting: ");
            long id = long.Parse(Console.ReadLine()!);
            ITaskRepository taskRepository = new TaskRepository();
            var task = await taskRepository.FindByIdAsync(id);
            Console.WriteLine("Please select options");
            Console.WriteLine(" 1.Do        2.Doing        3.Done");
            var dict = new Dictionary<string, string>()
            {
                { "1", "do" },
                { "2", "doing" },
                { "3", "done" }
            };

            task.Status = dict[Console.ReadLine()];
            var result = await taskRepository.UpdateAsync(id, task);
            if (result) Console.WriteLine("Muvaffaqqiyatli");
            else Console.WriteLine("Xatolik bo'ldi");
        }
    }
}
