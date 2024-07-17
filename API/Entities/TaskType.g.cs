using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tasktype entity with essential details
    /// </summary>
    public class TaskType
    {
        /// <summary>
        /// Initializes a new instance of the TaskType class.
        /// </summary>
        public TaskType()
        {
            DueOnNextVisit = false;
            SelfAssign = false;
        }

        /// <summary>
        /// Primary key for the TaskType 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TaskType belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the TaskType 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field DueOnNextVisit of the TaskType 
        /// </summary>
        [Required]
        public bool DueOnNextVisit { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the TaskType belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TaskType 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field SelfAssign of the TaskType 
        /// </summary>
        [Required]
        public bool SelfAssign { get; set; }
        /// <summary>
        /// DurationValue of the TaskType 
        /// </summary>
        public short? DurationValue { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the TaskType belongs 
        /// </summary>
        public Guid? DurationUom { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("DurationUom")]
        public UOM? DurationUom_UOM { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the TaskType belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the TaskType 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Description of the TaskType 
        /// </summary>
        public string? Description { get; set; }
    }
}