using to_do_list_app.Pages.Tasks;

namespace to_do_list_app.Pages
{
    public class TasksPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Barcha vazifalarni ko'rish");
            Console.WriteLine("2. Vazifa haqida ma'lumot");
            Console.WriteLine("3. Vazifa yaratish ");
            Console.WriteLine("4. Vazifani tahrirlash ");

            var choose = Console.ReadLine();
            if (choose == "1")
                await GetAllPage.RunAsync();
            else if (choose == "2")
                await GetPage.RunAsync();
            else if (choose == "3")
                await CreatePage.RunAsync();
            else if (choose == "4")
                await ManagePage.RunAsync();
            else
                Console.WriteLine("Tanlov xato amalga oshrildi");
        }
    }
}
