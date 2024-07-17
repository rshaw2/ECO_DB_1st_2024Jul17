using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationeventtemplates entity with essential details
    /// </summary>
    public class CommunicationEventTemplates
    {
        /// <summary>
        /// Primary key for the CommunicationEventTemplates 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationEventTemplates belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the CommunicationModuleEventTemplateRelation to which the CommunicationEventTemplates belongs 
        /// </summary>
        [Required]
        public Guid CommunicationModuleEventTemplateRelation { get; set; }

        /// <summary>
        /// Navigation property representing the associated CommunicationModuleEventTemplateRelation
        /// </summary>
        [ForeignKey("CommunicationModuleEventTemplateRelation")]
        public CommunicationModuleEventTemplateRelation? CommunicationModuleEventTemplateRelation_CommunicationModuleEventTemplateRelation { get; set; }

        /// <summary>
        /// Required field CommunicationType of the CommunicationEventTemplates 
        /// </summary>
        [Required]
        public byte CommunicationType { get; set; }

        /// <summary>
        /// Foreign key referencing the CommunicationTemplate to which the CommunicationEventTemplates belongs 
        /// </summary>
        [Required]
        public Guid CommunicationTemplateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CommunicationTemplate
        /// </summary>
        [ForeignKey("CommunicationTemplateId")]
        public CommunicationTemplate? CommunicationTemplateId_CommunicationTemplate { get; set; }
    }
}