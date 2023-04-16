using ConsoleTables;
using to_do_list_app.Common;
using to_do_list_app.Interfaces.Repositories;
using to_do_list_app.Repositories;

namespace to_do_list_app.Pages.Tasks
{
    public class GetAllPage
    {
        public static async Task RunAsync()
        {
            ITaskRepository taskRepository = new TaskRepository();
            var tasks = await taskRepository.GetAllByUserIdAsync(IdentitySingelton.GetInstance().UserId, 0, 20);
            ConsoleTable consoleTable = new ConsoleTable("Id", "Nomi", "Boshlanish vaqti", "Tugash vaqti", "Holati");
            foreach (var task in tasks)
            {
                consoleTable.AddRow(task.Id, task.Title, task.BeginTime, task.EndTime, task.Status);
            }
            consoleTable.Write();
        }
    }
}
