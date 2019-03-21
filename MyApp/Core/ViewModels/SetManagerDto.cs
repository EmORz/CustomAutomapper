using System.Collections.Generic;
using System.Linq;
using MyApp.Models;

namespace MyApp.Core.ViewModels
{
    public class SetManagerDto
    {
        public SetManagerDto()
        {
            this.ManagedEmployees = new List<EmployeeDto>();
        }
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<EmployeeDto> ManagedEmployees { get; set; }

        public override string ToString()
        {
            return $"Register set manager:  {this.ID} {this.FirstName} {this.LastName}!";
        }
    }
}