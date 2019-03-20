using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using MyApp.Core.Commands.Interface;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Core.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public string Execute(string[] inputArgs)
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var firstName = inputArgs[0];
            var lastName = inputArgs[1];
            var salary = decimal.Parse(inputArgs[2]);


            var emp = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.context.Add(emp);
            this.context.SaveChanges();

            var empDto = this.mapper.CreateMappedObject<EmployeeDto>(emp);

            var result = empDto.ToString();

            return result;
        }
    }

}