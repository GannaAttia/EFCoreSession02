namespace EFCoreSession02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ApplicationDBContext();

            context.Database.EnsureCreated();

            Console.WriteLine("EventHub Database created successfully");
        }
    }
}
