using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationmoduleeventrelation entity with essential details
    /// </summary>
    public class CommunicationModuleEventRelation
    {
        /// <summary>
        /// Primary key for the CommunicationModuleEventRelation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationModuleEventRelation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field CommunicationModule of the CommunicationModuleEventRelation 
        /// </summary>
        [Required]
        public byte CommunicationModule { get; set; }

        /// <summary>
        /// Required field CommunicationEvent of the CommunicationModuleEventRelation 
        /// </summary>
        [Required]
        public byte CommunicationEvent { get; set; }
    }
}