using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a aifields entity with essential details
    /// </summary>
    public class AiFields
    {
        /// <summary>
        /// Primary key for the AiFields 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AiFields belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field AiModule of the AiFields 
        /// </summary>
        [Required]
        public byte AiModule { get; set; }

        /// <summary>
        /// Required field Title of the AiFields 
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Required field Description of the AiFields 
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Required field AiFieldType of the AiFields 
        /// </summary>
        [Required]
        public byte AiFieldType { get; set; }
    }
}