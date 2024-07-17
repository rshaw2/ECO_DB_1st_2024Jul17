using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a jobitem entity with essential details
    /// </summary>
    public class JobItem
    {
        /// <summary>
        /// Initializes a new instance of the JobItem class.
        /// </summary>
        public JobItem()
        {
            IsStandard = false;
            Flagged = false;
        }

        /// <summary>
        /// Required field NextRunTime of the JobItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime NextRunTime { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the JobItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the JobItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the JobType to which the JobItem belongs 
        /// </summary>
        [Required]
        public Guid BatchTypeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated JobType
        /// </summary>
        [ForeignKey("BatchTypeId")]
        public JobType? BatchTypeId_JobType { get; set; }

        /// <summary>
        /// Required field Name of the JobItem 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field IsStandard of the JobItem 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// Active of the JobItem 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Flagged of the JobItem 
        /// </summary>
        public bool? Flagged { get; set; }
        /// <summary>
        /// EntityObjectSubTypeId of the JobItem 
        /// </summary>
        public Guid? EntityObjectSubTypeId { get; set; }
        /// <summary>
        /// BatchStatus of the JobItem 
        /// </summary>
        public Guid? BatchStatus { get; set; }
        /// <summary>
        /// HelpParameter of the JobItem 
        /// </summary>
        public string? HelpParameter { get; set; }
        /// <summary>
        /// Priority of the JobItem 
        /// </summary>
        public byte? Priority { get; set; }
        /// <summary>
        /// RetryCount of the JobItem 
        /// </summary>
        public short? RetryCount { get; set; }
        /// <summary>
        /// EntityCode of the JobItem 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// ReferenceId of the JobItem 
        /// </summary>
        public Guid? ReferenceId { get; set; }
        /// <summary>
        /// Status of the JobItem 
        /// </summary>
        public bool? Status { get; set; }
        /// <summary>
        /// FailedReason of the JobItem 
        /// </summary>
        public string? FailedReason { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the JobItem belongs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// CreatedOn of the JobItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// StartTime of the JobItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// EndTime of the JobItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// Code of the JobItem 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// EntitySubTypeCode of the JobItem 
        /// </summary>
        public string? EntitySubTypeCode { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the JobItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the JobItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ParentId of the JobItem 
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}