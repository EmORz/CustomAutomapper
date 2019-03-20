using System.ComponentModel.DataAnnotations;

namespace MyApp.Core.ViewModels
{
    public class EmployeeInfoDto
    {
        // format "ID: {employeeId} - {firstName} {lastName} -  ${salary:f2}"
        
        public int ID { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {this.ID} - {this.FirstName} {this.LastName} -  ${this.Salary}";
        }
    }
}