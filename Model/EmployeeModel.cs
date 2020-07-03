using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.EmployeeModel
{

public class Employee{

        [Required]
        public string employeeid{get;set;}
        [Required]
        [MaxLength(50)]
        public string name{get;set;}
        [Required]
        public string salary{get;set;}
        [Required]
        public string leaves{get;set;}
    }
}