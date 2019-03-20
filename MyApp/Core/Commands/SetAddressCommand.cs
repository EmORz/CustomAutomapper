using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using MyApp.Core.Commands.Interface;
using MyApp.Core.ViewModels;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private MyAppContext context;
        private Mapper mapper;

        public SetAddressCommand(MyAppContext context, Mapper mapper )
        {
            this.context = context;
            this.mapper = mapper;
        }
        //•	SetAddress <employeeId> <address> –  sets the address of the employee to the given string

        public string Execute(string[] inputArgs)
        {
            var employeeID = int.Parse(inputArgs[0]);
            var address = string.Join(" ", inputArgs.Skip(1).ToArray());

            var employee = context.Employees.FirstOrDefault(x => x.ID == employeeID);

            if (employee == null)
            {
                throw  new ArgumentNullException($"There is no such employee with ID {employeeID} ");
            }

            employee.Address = address;
            
            context.SaveChanges();

            var addressDto = this.mapper.CreateMappedObject<AddressDto>(employee);
            var result = addressDto.ToString();
            return result;
        }
    }
}