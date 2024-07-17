using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a jobstatus entity with essential details
    /// </summary>
    public class JobStatus
    {
        /// <summary>
        /// Initializes a new instance of the JobStatus class.
        /// </summary>
        public JobStatus()
        {
            IsStandard = false;
            Flagged = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the JobStatus belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the JobStatus 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the JobStatus 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the JobStatus 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the JobStatus 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field Active of the JobStatus 
        /// </summary>
        [Required]
        public Guid Active { get; set; }

        /// <summary>
        /// Required field Flagged of the JobStatus 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the JobStatus belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the JobStatus 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// ParentId of the JobStatus 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// EntityObjectSubTypeId of the JobStatus 
        /// </summary>
        public Guid? EntityObjectSubTypeId { get; set; }
        /// <summary>
        /// Code of the JobStatus 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the JobStatus 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the JobStatus belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the JobStatus 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}