using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationtemplatevariable entity with essential details
    /// </summary>
    public class CommunicationTemplateVariable
    {
        /// <summary>
        /// Primary key for the CommunicationTemplateVariable 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationTemplateVariable belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the CommunicationTemplate to which the CommunicationTemplateVariable belongs 
        /// </summary>
        [Required]
        public Guid CommunicationTemplateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CommunicationTemplate
        /// </summary>
        [ForeignKey("CommunicationTemplateId")]
        public CommunicationTemplate? CommunicationTemplateId_CommunicationTemplate { get; set; }

        /// <summary>
        /// Required field Sequence of the CommunicationTemplateVariable 
        /// </summary>
        [Required]
        public short Sequence { get; set; }

        /// <summary>
        /// Required field VariableField of the CommunicationTemplateVariable 
        /// </summary>
        [Required]
        public string VariableField { get; set; }
    }
}