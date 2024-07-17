using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a aimeter entity with essential details
    /// </summary>
    public class AiMeter
    {
        /// <summary>
        /// Primary key for the AiMeter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AiMeter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field StartDate of the AiMeter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required field EndDate of the AiMeter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Required field Limit of the AiMeter 
        /// </summary>
        [Required]
        public int Limit { get; set; }

        /// <summary>
        /// Required field Consumed of the AiMeter 
        /// </summary>
        [Required]
        public int Consumed { get; set; }

        /// <summary>
        /// Required field Active of the AiMeter 
        /// </summary>
        [Required]
        public bool Active { get; set; }
    }
}