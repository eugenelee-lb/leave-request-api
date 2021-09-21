using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequestAPI.Models
{
    public class LeaveRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveRequestId { get; set; }
        [Required]
        [StringLength(25)]
        public string EmployeeId { get; set; }
        [StringLength(50)]
        [Required]
        public string LeaveType { get; set; } // Vacation, Personal Leave, Banked Overtime, Sick Leave, Sick Family
        [Required]
        [StringLength(50)]
        public string LeaveTimeType { get; set; } // Leave Early, In Late, Full Day, Partial Day
        [StringLength(25)]
        public string LeaveAt { get; set; } // Leave At
        [StringLength(25)]
        public string InAt { get; set; }

        [Required]
        public bool IsMultiDays { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public decimal Hours { get; set; }
        [StringLength(25)]
        [Required]
        public string ApproverId { get; set; }
        [StringLength(25)]
        public string AlternateApproverId { get; set; }

        [Required]
        [StringLength(25)]
        public string RequestStatus { get; set; } // Pending, Approved
        [Required]
        public DateTime SubmitDate { get; set; }
        public DateTime? ApproveDate { get; set; }
        [StringLength(25)]
        public string ApproveBy { get; set; }

        public Employee Employee { get; set; }
    }

    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.Property(a => a.Hours).HasColumnType("decimal(7,2)");
        }
    }
}
