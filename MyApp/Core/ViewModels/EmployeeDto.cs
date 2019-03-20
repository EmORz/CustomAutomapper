namespace MyApp.Core.ViewModels
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Register successfully: {this.FirstName} {this.LastName} - {this.Salary:f2}";
        }

    }
}