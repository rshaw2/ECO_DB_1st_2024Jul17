using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a templatecomponents entity with essential details
    /// </summary>
    public class TemplateComponents
    {
        /// <summary>
        /// Primary key for the TemplateComponents 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TemplateComponents belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the EmrTemplate to which the TemplateComponents belongs 
        /// </summary>
        [Required]
        public Guid EmrTemplateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EmrTemplate
        /// </summary>
        [ForeignKey("EmrTemplateId")]
        public EmrTemplate? EmrTemplateId_EmrTemplate { get; set; }

        /// <summary>
        /// Required field Component of the TemplateComponents 
        /// </summary>
        [Required]
        public byte Component { get; set; }

        /// <summary>
        /// Required field Sequence of the TemplateComponents 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Visible of the TemplateComponents 
        /// </summary>
        [Required]
        public bool Visible { get; set; }
        /// <summary>
        /// Mandatory of the TemplateComponents 
        /// </summary>
        public bool? Mandatory { get; set; }
    }
}