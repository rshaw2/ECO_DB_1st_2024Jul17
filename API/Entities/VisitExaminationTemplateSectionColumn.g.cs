using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitexaminationtemplatesectioncolumn entity with essential details
    /// </summary>
    public class VisitExaminationTemplateSectionColumn
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitExaminationTemplateSectionColumn belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitExaminationTemplateSectionColumn 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitExaminationTemplateSection to which the VisitExaminationTemplateSectionColumn belongs 
        /// </summary>
        [Required]
        public Guid VisitExaminationTemplateSectionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitExaminationTemplateSection
        /// </summary>
        [ForeignKey("VisitExaminationTemplateSectionId")]
        public VisitExaminationTemplateSection? VisitExaminationTemplateSectionId_VisitExaminationTemplateSection { get; set; }
        /// <summary>
        /// Name of the VisitExaminationTemplateSectionColumn 
        /// </summary>
        public string? Name { get; set; }
    }
}