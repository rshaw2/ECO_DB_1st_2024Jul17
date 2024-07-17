using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationverification entity with essential details
    /// </summary>
    public class CommunicationVerification
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationVerification belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the CommunicationVerification 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field GenerateOn of the CommunicationVerification 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime GenerateOn { get; set; }

        /// <summary>
        /// ExpiresOn of the CommunicationVerification 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpiresOn { get; set; }
        /// <summary>
        /// OTP of the CommunicationVerification 
        /// </summary>
        public string? OTP { get; set; }
        /// <summary>
        /// Status of the CommunicationVerification 
        /// </summary>
        public bool? Status { get; set; }
    }
}