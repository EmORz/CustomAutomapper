using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.ViewModels
{
    public class ListOfEmployeeDto
    {
        public ListOfEmployeeDto()
        {
            this.ManagedEmployees = new List<EmployeeDto>();
        }
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }


        public List<EmployeeDto> ManagedEmployees { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            

            foreach (var employee in ManagedEmployees)
            {
                var str = $"{employee.FirstName} {employee.LastName} - ${employee.Salary} - Manager: {this.FirstName}";
                sb.AppendLine(str);
            }
            return sb.ToString().Trim();
        }
    }
}