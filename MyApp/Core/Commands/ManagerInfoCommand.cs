using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Commands.Interface;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //•	ManagerInfo <employeeId> – prints on the console information about a manager in the following format:

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);

            Employee manager = context.Employees
                .Include(m => m.ManagedEmployees)
                .FirstOrDefault(x => x.ID == employeeId);

            var managerDto = this.mapper.CreateMappedObject<ManagerDto>(manager);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.ManagedEmployees.Count}");

            foreach (var employee in managerDto.ManagedEmployees)
            {
                sb.AppendLine($"   - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
            }
            return sb.ToString().Trim();
        }
    }
}