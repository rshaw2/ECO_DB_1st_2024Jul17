using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a icdcode entity with essential details
    /// </summary>
    public class IcdCode
    {
        /// <summary>
        /// Primary key for the IcdCode 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the IcdCode belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Code of the IcdCode 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field Name of the IcdCode 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field IcdType of the IcdCode 
        /// </summary>
        [Required]
        public byte IcdType { get; set; }
    }
}