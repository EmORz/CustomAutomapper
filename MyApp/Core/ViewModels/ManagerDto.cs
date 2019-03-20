using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MyApp.Models;

namespace MyApp.Core.ViewModels
{
    public class ManagerDto
    {

        public ManagerDto()
        {
            this.ManagedEmployees = new List<EmployeeDto>();
        }
        public int ID { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public List<EmployeeDto> ManagedEmployees { get; set; }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine($"{this.FirstName} {this.LastName} | Employees: {this.ManagedEmployees.Count}");

        //    foreach (var employee in ManagedEmployees)
        //    {
        //        sb.AppendLine($"   - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
        //    }
        //    return sb.ToString();
        //}
    }
}