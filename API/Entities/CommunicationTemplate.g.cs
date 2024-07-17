using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationtemplate entity with essential details
    /// </summary>
    public class CommunicationTemplate
    {
        /// <summary>
        /// Primary key for the CommunicationTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field TemplateName of the CommunicationTemplate 
        /// </summary>
        [Required]
        public string TemplateName { get; set; }

        /// <summary>
        /// Required field CommunicationType of the CommunicationTemplate 
        /// </summary>
        [Required]
        public byte CommunicationType { get; set; }

        /// <summary>
        /// Required field CommunicationModule of the CommunicationTemplate 
        /// </summary>
        [Required]
        public byte CommunicationModule { get; set; }

        /// <summary>
        /// Required field CommunicationEvent of the CommunicationTemplate 
        /// </summary>
        [Required]
        public byte CommunicationEvent { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CommunicationTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CommunicationTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field CommunicationFor of the CommunicationTemplate 
        /// </summary>
        [Required]
        public byte CommunicationFor { get; set; }
        /// <summary>
        /// CommunicationProvider of the CommunicationTemplate 
        /// </summary>
        public byte? CommunicationProvider { get; set; }
        /// <summary>
        /// SMSProviderTemplateId of the CommunicationTemplate 
        /// </summary>
        public string? SMSProviderTemplateId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CommunicationTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the CommunicationTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Subject of the CommunicationTemplate 
        /// </summary>
        public string? Subject { get; set; }
        /// <summary>
        /// Content of the CommunicationTemplate 
        /// </summary>
        public string? Content { get; set; }
    }
}