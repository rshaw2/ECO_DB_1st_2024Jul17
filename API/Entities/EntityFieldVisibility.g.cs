using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entityfieldvisibility entity with essential details
    /// </summary>
    public class EntityFieldVisibility
    {
        /// <summary>
        /// Primary key for the EntityFieldVisibility 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the EntityFieldVisibility belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field EntityName of the EntityFieldVisibility 
        /// </summary>
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// Required field PropertyName of the EntityFieldVisibility 
        /// </summary>
        [Required]
        public string PropertyName { get; set; }

        /// <summary>
        /// Required field HideVisible of the EntityFieldVisibility 
        /// </summary>
        [Required]
        public bool HideVisible { get; set; }
    }
}