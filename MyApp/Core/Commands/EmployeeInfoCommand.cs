using System.Linq;
using AutoMapper;
using MyApp.Core.Commands.Interface;
using MyApp.Core.ViewModels;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private MyAppContext context;

        private Mapper mapper;

        public EmployeeInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //•	EmployeeInfo <employeeId> – prints on the console the information for an employee
        //in the format "ID: {employeeId} - {firstName} {lastName} -  ${salary:f2}"
        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);

            var employee = context.Employees.FirstOrDefault(x => x.ID == employeeId);

            var employeeInformation = this.mapper.CreateMappedObject<EmployeeInfoDto>(employee);

            var result = employeeInformation.ToString();

            return result;
        }
    }
}