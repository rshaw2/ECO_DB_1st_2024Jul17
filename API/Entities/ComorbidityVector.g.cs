using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a comorbidityvector entity with essential details
    /// </summary>
    public class ComorbidityVector
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ComorbidityVector belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ComorbidityVector 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Comorbidity to which the ComorbidityVector belongs 
        /// </summary>
        [Required]
        public Guid ComorbidityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Comorbidity
        /// </summary>
        [ForeignKey("ComorbidityId")]
        public Comorbidity? ComorbidityId_Comorbidity { get; set; }

        /// <summary>
        /// Required field VectorValue of the ComorbidityVector 
        /// </summary>
        [Required]
        public string VectorValue { get; set; }

        /// <summary>
        /// SyncDate of the ComorbidityVector 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SyncDate { get; set; }
    }
}