using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TicTacToe.Data;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            try
            {
                var scope = host.Services.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                ctx.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
