using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequestAPI.Models
{
    public class Employee
    {
        [Key]
        [StringLength(25)]
        public string EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public bool IsSupervisor { get; set; }
        [StringLength(25)]
        public string SupervisorId { get; set; }
    }
}
