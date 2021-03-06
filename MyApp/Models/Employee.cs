﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Employee
    {
        public Employee()
        {
            this.ManagedEmployees = new List<Employee>();
        }
        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335") ]
        public decimal Salary { get; set; }

        public DateTime? BirthDay { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> ManagedEmployees { get; set; }
    }
}