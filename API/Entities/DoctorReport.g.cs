using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a doctorreport entity with essential details
    /// </summary>
    public class DoctorReport
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the DoctorReport belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DoctorReport 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Report to which the DoctorReport belongs 
        /// </summary>
        [Required]
        public Guid ReportId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Report
        /// </summary>
        [ForeignKey("ReportId")]
        public Report? ReportId_Report { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorReport belongs 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }

        /// <summary>
        /// Required field Favourite of the DoctorReport 
        /// </summary>
        [Required]
        public bool Favourite { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorReport belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DoctorReport 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DoctorReport belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DoctorReport 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Name of the DoctorReport 
        /// </summary>
        public string? Name { get; set; }
    }
}