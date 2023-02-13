using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNet_Project8.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Address { get; set; }
        public int Salary { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public Designation Designation { get; set; }
    }
}