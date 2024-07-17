using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a aiprovidersettings entity with essential details
    /// </summary>
    public class AiProviderSettings
    {
        /// <summary>
        /// Primary key for the AiProviderSettings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AiProviderSettings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field ProviderName of the AiProviderSettings 
        /// </summary>
        [Required]
        public string ProviderName { get; set; }

        /// <summary>
        /// Required field Version of the AiProviderSettings 
        /// </summary>
        [Required]
        public string Version { get; set; }

        /// <summary>
        /// Required field ApiKey of the AiProviderSettings 
        /// </summary>
        [Required]
        public string ApiKey { get; set; }

        /// <summary>
        /// Required field SystemDefault of the AiProviderSettings 
        /// </summary>
        [Required]
        public bool SystemDefault { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the AiProviderSettings belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the AiProviderSettings 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the AiProviderSettings belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the AiProviderSettings 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Active of the AiProviderSettings 
        /// </summary>
        public bool? Active { get; set; }
    }
}