using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequestAPI.Models
{
    public class EmployeeAccrual
    {
        public string EmployeeId { get; set; }
        [StringLength(50)]
        public string AccrualType { get; set; } // Vacation, Personal Leave, Sick Leave, Banked Overtime
        [Required]
        public decimal Hours { get; set; }

        public Employee Employee { get; set; }
    }

    public class EmployeeAccrualConfiguration : IEntityTypeConfiguration<EmployeeAccrual>
    {
        public void Configure(EntityTypeBuilder<EmployeeAccrual> builder)
        {
            builder.HasKey(a => new { a.EmployeeId, a.AccrualType });
            builder.Property(a => a.Hours).HasColumnType("decimal(7,2)");
        }
    }
}
