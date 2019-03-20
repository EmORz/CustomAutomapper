using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Interfaces;

namespace MyApp.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider provider;

        public Engine(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public void Run()
        {
            while (true)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var commandinterpreter = this.provider.GetService<ICommandInterpreter>();
                var result = commandinterpreter.Read(inputArgs);

                Console.WriteLine(result);
            }

        }
    }
}