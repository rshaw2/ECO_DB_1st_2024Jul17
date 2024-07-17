using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a settings entity with essential details
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the Settings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Settings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field UpdatedOn of the Settings 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Settings belongs 
        /// </summary>
        [Required]
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }
        /// <summary>
        /// Context of the Settings 
        /// </summary>
        public int? Context { get; set; }
        /// <summary>
        /// Content of the Settings 
        /// </summary>
        public string? Content { get; set; }
    }
}