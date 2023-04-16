using to_do_list_app.Common;
using to_do_list_app.Interfaces.Repositories;
using to_do_list_app.Repositories;


namespace to_do_list_app.Pages.Tasks
{
    public class CreatePage
    {
        public static async System.Threading.Tasks.Task RunAsync()
        {
            Console.Clear();
            var task = new ToDoListApp.Models.Task();

            Console.Write("Vazifa nomi: ");
            task.Title = Console.ReadLine()!;

            Console.Write("Batafsil: ");
            task.Description = Console.ReadLine()!;

            Console.Write("Boshlanish vaqti: ");
            task.BeginTime = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Tugash vaqti: ");
            task.EndTime = DateTime.Parse(Console.ReadLine()!);

            task.OwnerId = IdentitySingelton.GetInstance().UserId;
            task.Status = "Do".ToLower();
            task.CreatedAt = DateTime.Now;

            ITaskRepository taskRepository = new TaskRepository();
            var result = await taskRepository.CreateAsync(task);
            if (result) Console.WriteLine("Muvaffaqqiyatli");
            else Console.WriteLine("Xatolik bo'ladi!");
        }
    }
}
