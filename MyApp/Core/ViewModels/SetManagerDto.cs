using System.Collections.Generic;
using System.Linq;
using MyApp.Models;

namespace MyApp.Core.ViewModels
{
    public class SetManagerDto
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> ManagerEmployees { get; set; }

        public override string ToString()
        {
            return $"Register set manager!";
        }
    }
}