using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a emrtemplate entity with essential details
    /// </summary>
    public class EmrTemplate
    {
        /// <summary>
        /// Initializes a new instance of the EmrTemplate class.
        /// </summary>
        public EmrTemplate()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the User to which the EmrTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the EmrTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the EmrTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the EmrTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field IsStandard of the EmrTemplate 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the EmrTemplate belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the EmrTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the EmrTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitType to which the EmrTemplate belongs 
        /// </summary>
        public Guid? VisitTypeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitType
        /// </summary>
        [ForeignKey("VisitTypeId")]
        public VisitType? VisitTypeId_VisitType { get; set; }
        /// <summary>
        /// Enabled of the EmrTemplate 
        /// </summary>
        public bool? Enabled { get; set; }
        /// <summary>
        /// Name of the EmrTemplate 
        /// </summary>
        public string? Name { get; set; }
    }
}