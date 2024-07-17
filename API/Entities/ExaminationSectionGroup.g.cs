using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a examinationsectiongroup entity with essential details
    /// </summary>
    public class ExaminationSectionGroup
    {
        /// <summary>
        /// Primary key for the ExaminationSectionGroup 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ExaminationSectionGroup belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ExaminationSection to which the ExaminationSectionGroup belongs 
        /// </summary>
        [Required]
        public Guid ExaminationSectionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ExaminationSection
        /// </summary>
        [ForeignKey("ExaminationSectionId")]
        public ExaminationSection? ExaminationSectionId_ExaminationSection { get; set; }

        /// <summary>
        /// Required field GroupType of the ExaminationSectionGroup 
        /// </summary>
        [Required]
        public byte GroupType { get; set; }

        /// <summary>
        /// Required field Sequence of the ExaminationSectionGroup 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the ExaminationSectionGroup belongs 
        /// </summary>
        public Guid? ClinicalParameterId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameterId")]
        public ClinicalParameter? ClinicalParameterId_ClinicalParameter { get; set; }
        /// <summary>
        /// Name of the ExaminationSectionGroup 
        /// </summary>
        public string? Name { get; set; }
    }
}