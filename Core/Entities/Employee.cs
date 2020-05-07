using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }

        [Column("DepartmentId")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
    }
}
