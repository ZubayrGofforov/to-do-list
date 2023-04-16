using to_do_list_app.Pages;

class Programm
{
    public static async Task Main()
    {
        Console.WriteLine(" 1. Login         2. Register");
        var choose = Console.ReadLine();
        if (choose == "1")
        {
            await LoginPage.RunAsync();
        }
        else if (choose == "2")
        {
            await RegisterPage.RunAsync();
        }
        else
        {
            Console.WriteLine(" Xato tanlov amalga oshirildi!");
            Thread.Sleep(1000);
            await Main();
        }
    }
}