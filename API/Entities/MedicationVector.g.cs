using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicationvector entity with essential details
    /// </summary>
    public class MedicationVector
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the MedicationVector belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the MedicationVector 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field MedicationId of the MedicationVector 
        /// </summary>
        [Required]
        public Guid MedicationId { get; set; }

        /// <summary>
        /// Required field VectorValue of the MedicationVector 
        /// </summary>
        [Required]
        public string VectorValue { get; set; }

        /// <summary>
        /// SyncDate of the MedicationVector 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SyncDate { get; set; }
    }
}