using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a reportaccess entity with essential details
    /// </summary>
    public class ReportAccess
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ReportAccess belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ReportAccess 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Report to which the ReportAccess belongs 
        /// </summary>
        [Required]
        public Guid ReportId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Report
        /// </summary>
        [ForeignKey("ReportId")]
        public Report? ReportId_Report { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ReportAccess belongs 
        /// </summary>
        [Required]
        public Guid AccessedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("AccessedBy")]
        public User? AccessedBy_User { get; set; }

        /// <summary>
        /// Required field AccessedOn of the ReportAccess 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime AccessedOn { get; set; }
    }
}