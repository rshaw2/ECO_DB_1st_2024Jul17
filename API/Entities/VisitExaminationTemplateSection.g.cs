using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitexaminationtemplatesection entity with essential details
    /// </summary>
    public class VisitExaminationTemplateSection
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitExaminationTemplateSection belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitExaminationTemplateSection 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitExaminationTemplate to which the VisitExaminationTemplateSection belongs 
        /// </summary>
        [Required]
        public Guid VisitExaminationTemplateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitExaminationTemplate
        /// </summary>
        [ForeignKey("VisitExaminationTemplateId")]
        public VisitExaminationTemplate? VisitExaminationTemplateId_VisitExaminationTemplate { get; set; }

        /// <summary>
        /// Required field Name of the VisitExaminationTemplateSection 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field ColumnLayout of the VisitExaminationTemplateSection 
        /// </summary>
        [Required]
        public byte ColumnLayout { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitExaminationTemplateSection 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
    }
}