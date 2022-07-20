using System.Data.SqlClient;

class Program
{
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        var app = builder.Build();
        app.UseFileServer();
        app.UseRouting();
        app.MapControllers();
        app.Run();
    }
}