using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a examinationsection entity with essential details
    /// </summary>
    public class ExaminationSection
    {
        /// <summary>
        /// Primary key for the ExaminationSection 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ExaminationSection belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the ExaminationSection 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field ColumnLayout of the ExaminationSection 
        /// </summary>
        [Required]
        public byte ColumnLayout { get; set; }

        /// <summary>
        /// Required field IsStandard of the ExaminationSection 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ExaminationSection belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ExaminationSection 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ExaminationSection belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ExaminationSection 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// OneColumnTitle of the ExaminationSection 
        /// </summary>
        public string? OneColumnTitle { get; set; }
        /// <summary>
        /// TwoColumnTitle of the ExaminationSection 
        /// </summary>
        public string? TwoColumnTitle { get; set; }
        /// <summary>
        /// ThreeColumnTitle of the ExaminationSection 
        /// </summary>
        public string? ThreeColumnTitle { get; set; }
        /// <summary>
        /// FourColumnTitle of the ExaminationSection 
        /// </summary>
        public string? FourColumnTitle { get; set; }
        /// <summary>
        /// Description of the ExaminationSection 
        /// </summary>
        public string? Description { get; set; }
    }
}