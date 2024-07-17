using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationmoduletemplates entity with essential details
    /// </summary>
    public class CommunicationModuleTemplates
    {
        /// <summary>
        /// Primary key for the CommunicationModuleTemplates 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationModuleTemplates belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the CommunicationModuleEventRelation to which the CommunicationModuleTemplates belongs 
        /// </summary>
        [Required]
        public Guid CommunicationModuleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CommunicationModuleEventRelation
        /// </summary>
        [ForeignKey("CommunicationModuleId")]
        public CommunicationModuleEventRelation? CommunicationModuleId_CommunicationModuleEventRelation { get; set; }

        /// <summary>
        /// Required field CommunicationType of the CommunicationModuleTemplates 
        /// </summary>
        [Required]
        public byte CommunicationType { get; set; }

        /// <summary>
        /// Foreign key referencing the CommunicationTemplate to which the CommunicationModuleTemplates belongs 
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