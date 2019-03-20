using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using MyApp.Core.Commands.Interface;
using MyApp.Core.ViewModels;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {

        private MyAppContext context;
        private Mapper mapper;

        public SetBirthdayCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //•	SetBirthday <employeeId> <date: "dd-MM-yyyy"> – sets the birthday of the employee to the given date
        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);
            var date = DateTime.TryParseExact(inputArgs[1], "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);

            var employee = context.Employees.FirstOrDefault(x => x.ID == employeeId);

            if (employee==null)
            {
                throw  new ArgumentNullException($"There is no employee with ID: {employeeId}!");
            }
            if (!date)
            {
                throw  new ArgumentException("Not correct input birthdate! Cant be parse :)");
            }

            employee.BirthDay = result;
            this.context.SaveChanges();

            var addressDto = this.mapper.CreateMappedObject<BirthdayDto>(employee);
            var result1 = addressDto.ToString();
            return result1;
        }
    }
}