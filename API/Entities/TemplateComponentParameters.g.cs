using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a templatecomponentparameters entity with essential details
    /// </summary>
    public class TemplateComponentParameters
    {
        /// <summary>
        /// Primary key for the TemplateComponentParameters 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TemplateComponentParameters belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the TemplateComponents to which the TemplateComponentParameters belongs 
        /// </summary>
        [Required]
        public Guid TemplateComponentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated TemplateComponents
        /// </summary>
        [ForeignKey("TemplateComponentId")]
        public TemplateComponents? TemplateComponentId_TemplateComponents { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the TemplateComponentParameters belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameterId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameterId")]
        public ClinicalParameter? ClinicalParameterId_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field Name of the TemplateComponentParameters 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Sequence of the TemplateComponentParameters 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
        /// <summary>
        /// Code of the TemplateComponentParameters 
        /// </summary>
        public string? Code { get; set; }
    }
}