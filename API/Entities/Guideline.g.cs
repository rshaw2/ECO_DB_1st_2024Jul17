using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a guideline entity with essential details
    /// </summary>
    public class Guideline
    {
        /// <summary>
        /// Initializes a new instance of the Guideline class.
        /// </summary>
        public Guideline()
        {
            IsDeleted = false;
            Flagged = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Guideline belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Guideline 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field GuidelineText of the Guideline 
        /// </summary>
        [Required]
        public string GuidelineText { get; set; }

        /// <summary>
        /// Required field Sequence of the Guideline 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field IsDeleted of the Guideline 
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Required field Flagged of the Guideline 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Required field EntityCode of the Guideline 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Guideline 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Guideline belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Guideline 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the Guideline 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the Guideline 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Guideline belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Guideline 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// User of the Guideline 
        /// </summary>
        public Guid? User { get; set; }
        /// <summary>
        /// Code of the Guideline 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Guideline 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the Guideline 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// GuidelineGroup of the Guideline 
        /// </summary>
        public bool? GuidelineGroup { get; set; }
    }
}