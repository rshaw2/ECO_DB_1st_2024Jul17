using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a jobtype entity with essential details
    /// </summary>
    public class JobType
    {
        /// <summary>
        /// Initializes a new instance of the JobType class.
        /// </summary>
        public JobType()
        {
            Type = new Guid("00000000-0000-0000-0000-000000000000");
            IsStandard = false;
            Context = new Guid("00000000-0000-0000-0000-000000000000");
            Active = new Guid("00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the JobType belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the JobType 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the JobType 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the JobType 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IdleTime of the JobType 
        /// </summary>
        [Required]
        public int IdleTime { get; set; }

        /// <summary>
        /// Required field ItemTimeout of the JobType 
        /// </summary>
        [Required]
        public int ItemTimeout { get; set; }

        /// <summary>
        /// Required field ItemRetryCount of the JobType 
        /// </summary>
        [Required]
        public short ItemRetryCount { get; set; }

        /// <summary>
        /// Required field Type of the JobType 
        /// </summary>
        [Required]
        public Guid Type { get; set; }

        /// <summary>
        /// Required field IsStandard of the JobType 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the BatchTypeContext to which the JobType belongs 
        /// </summary>
        [Required]
        public Guid Context { get; set; }

        /// <summary>
        /// Navigation property representing the associated BatchTypeContext
        /// </summary>
        [ForeignKey("Context")]
        public BatchTypeContext? Context_BatchTypeContext { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the JobType belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the JobType 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the JobType belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the JobType 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ParentId of the JobType 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Active of the JobType 
        /// </summary>
        public Guid? Active { get; set; }

        /// <summary>
        /// StartDate of the JobType 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// EndDate of the JobType 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// SchedulerId of the JobType 
        /// </summary>
        public Guid? SchedulerId { get; set; }
        /// <summary>
        /// Code of the JobType 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the JobType 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Priority of the JobType 
        /// </summary>
        public byte? Priority { get; set; }
    }
}