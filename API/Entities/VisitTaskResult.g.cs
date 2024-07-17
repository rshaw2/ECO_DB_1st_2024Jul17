using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visittaskresult entity with essential details
    /// </summary>
    public class VisitTaskResult
    {
        /// <summary>
        /// Primary key for the VisitTaskResult 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitTaskResult belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitTask to which the VisitTaskResult belongs 
        /// </summary>
        [Required]
        public Guid VisitTaskId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitTask
        /// </summary>
        [ForeignKey("VisitTaskId")]
        public VisitTask? VisitTaskId_VisitTask { get; set; }

        /// <summary>
        /// Foreign key referencing the FollowupResult to which the VisitTaskResult belongs 
        /// </summary>
        [Required]
        public Guid FollowUpResultId { get; set; }

        /// <summary>
        /// Navigation property representing the associated FollowupResult
        /// </summary>
        [ForeignKey("FollowUpResultId")]
        public FollowupResult? FollowUpResultId_FollowupResult { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitTaskResult belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitTaskResult 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitTaskResult belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitTaskResult 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Notes of the VisitTaskResult 
        /// </summary>
        public string? Notes { get; set; }
    }
}