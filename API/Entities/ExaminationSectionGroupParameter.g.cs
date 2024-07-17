using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a examinationsectiongroupparameter entity with essential details
    /// </summary>
    public class ExaminationSectionGroupParameter
    {
        /// <summary>
        /// Primary key for the ExaminationSectionGroupParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ExaminationSectionGroupParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ExaminationSectionGroup to which the ExaminationSectionGroupParameter belongs 
        /// </summary>
        [Required]
        public Guid ExaminationSectionGroupId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ExaminationSectionGroup
        /// </summary>
        [ForeignKey("ExaminationSectionGroupId")]
        public ExaminationSectionGroup? ExaminationSectionGroupId_ExaminationSectionGroup { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the ExaminationSectionGroupParameter belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameterId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameterId")]
        public ClinicalParameter? ClinicalParameterId_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field Sequence of the ExaminationSectionGroupParameter 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
    }
}