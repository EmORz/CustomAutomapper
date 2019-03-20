using System;

namespace MyApp.Core.ViewModels
{
    public class EmployeePersonalInfoDto
    {
        public int ID { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public decimal Salary { get; set; }

        public DateTime BirthDay { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            var fullName = $"{this.FirstName} {this.LastName}";
            return $"ID: {this.ID} - {fullName} - ${this.Salary:f2} Birthday: {this.BirthDay} Address: {this.Address}";
        }
    }
}