using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationmoduleeventtemplaterelation entity with essential details
    /// </summary>
    public class CommunicationModuleEventTemplateRelation
    {
        /// <summary>
        /// Primary key for the CommunicationModuleEventTemplateRelation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationModuleEventTemplateRelation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field CommunicationModule of the CommunicationModuleEventTemplateRelation 
        /// </summary>
        [Required]
        public byte CommunicationModule { get; set; }

        /// <summary>
        /// Required field CommunicationEvent of the CommunicationModuleEventTemplateRelation 
        /// </summary>
        [Required]
        public byte CommunicationEvent { get; set; }

        /// <summary>
        /// Required field Active of the CommunicationModuleEventTemplateRelation 
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CommunicationModuleEventTemplateRelation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CommunicationModuleEventTemplateRelation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CommunicationModuleEventTemplateRelation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the CommunicationModuleEventTemplateRelation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}