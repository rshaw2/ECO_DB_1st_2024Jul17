using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a integrationusertoken entity with essential details
    /// </summary>
    public class IntegrationUserToken
    {
        /// <summary>
        /// Primary key for the IntegrationUserToken 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the IntegrationUserToken belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the IntegrationUser to which the IntegrationUserToken belongs 
        /// </summary>
        [Required]
        public Guid IntegrationUserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated IntegrationUser
        /// </summary>
        [ForeignKey("IntegrationUserId")]
        public IntegrationUser? IntegrationUserId_IntegrationUser { get; set; }

        /// <summary>
        /// Required field Token of the IntegrationUserToken 
        /// </summary>
        [Required]
        public string Token { get; set; }

        /// <summary>
        /// Required field Active of the IntegrationUserToken 
        /// </summary>
        [Required]
        public bool Active { get; set; }
    }
}