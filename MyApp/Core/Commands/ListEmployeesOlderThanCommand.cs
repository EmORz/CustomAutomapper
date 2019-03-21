using System;
using System.Linq;
using AutoMapper;
using MyApp.Core.Commands.Interface;
using MyApp.Core.ViewModels;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private MyAppContext context;

        private Mapper mapper;

        public ListEmployeesOlderThanCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var age = int.Parse(inputArgs[0]);

            var employees = context.Employees.Where(x => DateTime.Now.Year - (x.BirthDay.Value.Year)>age).ToList();

            if (employees.Count == 0)
            {
                throw  new ArgumentException("There is no employees with that age!");
            }

            var addressDto = this.mapper.CreateMappedObject<ListOfEmployeeDto>(employees);

            var result1 = addressDto.ToString();

            return result1;

        }
        
    }
}