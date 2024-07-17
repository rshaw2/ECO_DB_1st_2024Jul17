using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a examinationtemplatesection entity with essential details
    /// </summary>
    public class ExaminationTemplateSection
    {
        /// <summary>
        /// Primary key for the ExaminationTemplateSection 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ExaminationTemplateSection belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ExaminationTemplate to which the ExaminationTemplateSection belongs 
        /// </summary>
        [Required]
        public Guid ExaminationTemplateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ExaminationTemplate
        /// </summary>
        [ForeignKey("ExaminationTemplateId")]
        public ExaminationTemplate? ExaminationTemplateId_ExaminationTemplate { get; set; }

        /// <summary>
        /// Foreign key referencing the ExaminationSection to which the ExaminationTemplateSection belongs 
        /// </summary>
        [Required]
        public Guid ExaminationSectionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ExaminationSection
        /// </summary>
        [ForeignKey("ExaminationSectionId")]
        public ExaminationSection? ExaminationSectionId_ExaminationSection { get; set; }

        /// <summary>
        /// Required field Sequence of the ExaminationTemplateSection 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
    }
}