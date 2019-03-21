using System;
using System.Globalization;

namespace SandboxForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var age = int.Parse(Console.ReadLine());

            //Method callculate age datetime.now - birthdate = age
            CalclateAge(age);


        }

        private static void CalclateAge(int age)
        {
            var testDate = DateTime.Now.Year - DateTime.Parse("21-03-1986", CultureInfo.InstalledUICulture).Year;

            throw new NotImplementedException();
        }
    }
}
