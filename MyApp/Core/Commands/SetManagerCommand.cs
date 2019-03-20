using System;
using System.Linq;
using AutoMapper;
using MyApp.Core.Commands.Interface;
using MyApp.Core.ViewModels;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetManagerCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //•	SetManager <employeeId> <managerId> – sets the second employee to be a manager of the first employee
        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);
            var managerId = int.Parse(inputArgs[1]);

            //todo add validation null exception
            var employee = context.Employees.Find(employeeId);
            var manager = context.Employees.Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentNullException($"You have null value!");
                
            }

            employee.Manager = manager;
            this.context.SaveChanges();

            var addressDto = this.mapper.CreateMappedObject<SetManagerDto>(employee);
            var result1 = addressDto.ToString();
            return result1;
            
        }
    }
}