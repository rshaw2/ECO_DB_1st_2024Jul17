using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitguideline entity with essential details
    /// </summary>
    public class VisitGuideline
    {
        /// <summary>
        /// Initializes a new instance of the VisitGuideline class.
        /// </summary>
        public VisitGuideline()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitGuideline belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitGuideline 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitGuideline belongs 
        /// </summary>
        [Required]
        public Guid Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }

        /// <summary>
        /// Required field Guideline of the VisitGuideline 
        /// </summary>
        [Required]
        public Guid Guideline { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitGuideline 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitGuideline 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitGuideline belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitGuideline 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitGuideline 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the VisitGuideline 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Sequence of the VisitGuideline 
        /// </summary>
        public int? Sequence { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitGuideline belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitGuideline 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the VisitGuideline 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitGuideline 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitGuideline 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Patient of the VisitGuideline 
        /// </summary>
        public Guid? Patient { get; set; }
    }
}