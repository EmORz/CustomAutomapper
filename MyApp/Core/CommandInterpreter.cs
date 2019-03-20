using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Commands.Interface;
using MyApp.Core.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace MyApp.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public string Read(string[] inputArgs)
        {
            string command = inputArgs[0] + Suffix;
            string[] commandParams = inputArgs.Skip(1).ToArray();

            

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == command);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid command!");
            }

            var constructor = type.GetConstructors().FirstOrDefault();

            var constructorParams = constructor.GetParameters().Select(x => x.ParameterType).ToArray();

            var services = constructorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var commands = (ICommand)constructor
                .Invoke(services);

            var result = commands.Execute(commandParams);

            return result;

        }
    }
}