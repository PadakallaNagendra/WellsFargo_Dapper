using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsFargo_BusinessEntities.Entities
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Designation { get; set; }
        public string? Address { get; set; }
    }
}
