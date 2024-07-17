using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationprovidersettings entity with essential details
    /// </summary>
    public class CommunicationProviderSettings
    {
        /// <summary>
        /// Primary key for the CommunicationProviderSettings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationProviderSettings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field CommunicationType of the CommunicationProviderSettings 
        /// </summary>
        [Required]
        public byte CommunicationType { get; set; }

        /// <summary>
        /// Required field CommunicationProvider of the CommunicationProviderSettings 
        /// </summary>
        [Required]
        public byte CommunicationProvider { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CommunicationProviderSettings belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CommunicationProviderSettings 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Active of the CommunicationProviderSettings 
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// Required field SystemDefault of the CommunicationProviderSettings 
        /// </summary>
        [Required]
        public bool SystemDefault { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CommunicationProviderSettings belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the CommunicationProviderSettings 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Settings of the CommunicationProviderSettings 
        /// </summary>
        public string? Settings { get; set; }
    }
}