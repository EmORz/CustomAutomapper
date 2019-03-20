using AutoMapper;
using MyApp.Core.Commands.Interface;
using MyApp.Data;
using System.Linq;
using MyApp.Core.ViewModels;

namespace MyApp.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {

            var employeeId = int.Parse(inputArgs[0]);

            var employee = context.Employees.FirstOrDefault(x => x.ID == employeeId);

            var employeeInformation = this.mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee);

            var result = employeeInformation.ToString();

            return result;
        }
    }
}