using System;
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

            var employees = context.Employees
                .Include(m => m.ManagedEmployees)
                .Where(x => DateTime.Now.Year - (x.BirthDay.Value.Year) > age)
                .Select(s => new
                {
                    Emp = s.FirstName + " " + s.LastName,
                    Manager = s.Manager.FirstName,
                    Salary = s.Salary
                })
                .ToList()
                .OrderByDescending(x => x.Salary);

            if (employees == null)
            {
                throw new ArgumentException("There is no employees with that age!");
            }
            //var listOfEmployeeDto = this.mapper.CreateMappedObject<ManagerDto>(employees);
            //Todo add Dtos - how?
            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                var str = "";
                var temp = employee.Manager;

                if (temp == null)
                {
                    temp = "[no manager]";
                }

                str = $"{employee.Emp}  - ${employee.Salary} - Manager: {temp}";

                sb.AppendLine(str);
            }
            return sb.ToString().Trim();
        }

    }
}