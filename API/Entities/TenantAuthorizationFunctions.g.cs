using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantauthorizationfunctions entity with essential details
    /// </summary>
    public class TenantAuthorizationFunctions
    {
        /// <summary>
        /// Primary key for the TenantAuthorizationFunctions 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantAuthorizationFunctions belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field AuthorizationFunction of the TenantAuthorizationFunctions 
        /// </summary>
        [Required]
        public byte AuthorizationFunction { get; set; }

        /// <summary>
        /// Required field Value of the TenantAuthorizationFunctions 
        /// </summary>
        [Required]
        public bool Value { get; set; }
    }
}