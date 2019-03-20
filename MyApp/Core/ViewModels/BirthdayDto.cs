using System;

namespace MyApp.Core.ViewModels
{
    public class BirthdayDto
    {

        public DateTime BirthDay { get; set; }


        public override string ToString()
        {
            return $"Set birthday successfully: {this.BirthDay}";
        }
    }
}