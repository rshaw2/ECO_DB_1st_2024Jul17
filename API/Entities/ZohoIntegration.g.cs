using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a zohointegration entity with essential details
    /// </summary>
    public class ZohoIntegration
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ZohoIntegration belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ZohoIntegration 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field AccessToken of the ZohoIntegration 
        /// </summary>
        [Required]
        public string AccessToken { get; set; }

        /// <summary>
        /// Required field RefreshToken of the ZohoIntegration 
        /// </summary>
        [Required]
        public string RefreshToken { get; set; }
    }
}