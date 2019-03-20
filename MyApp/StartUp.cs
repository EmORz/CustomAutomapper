using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core;
using MyApp.Core.Interfaces;
using MyApp.Data;

namespace MyApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureService();

            IEngine engine = new Engine(serviceProvider);
            engine.Run();

        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<MyAppContext>(options =>
                options.UseSqlServer(@"Server=DESKTOP-CP2NEHV\SQLEXPRESS;Database=EmployeeAutoMapper;Integrated Security = true;"));
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<Mapper>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;

        }
    }
}
