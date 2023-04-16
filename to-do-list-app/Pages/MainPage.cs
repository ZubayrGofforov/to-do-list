namespace to_do_list_app.Pages
{
    public class MainPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Vazifalar ");
            Console.WriteLine("2. Profil sozlamalar ");

            var choose = Console.ReadLine();
            if (choose == "1")
                await TasksPage.RunAsync();
            else
                Console.WriteLine("Tanlov xato amalga oshrildi");
        }
    }
}
