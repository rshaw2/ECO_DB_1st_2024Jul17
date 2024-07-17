using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a allergyvector entity with essential details
    /// </summary>
    public class AllergyVector
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the AllergyVector belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the AllergyVector 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Allergy to which the AllergyVector belongs 
        /// </summary>
        [Required]
        public Guid AllergyId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Allergy
        /// </summary>
        [ForeignKey("AllergyId")]
        public Allergy? AllergyId_Allergy { get; set; }

        /// <summary>
        /// Required field VectorValue of the AllergyVector 
        /// </summary>
        [Required]
        public string VectorValue { get; set; }

        /// <summary>
        /// SyncDate of the AllergyVector 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SyncDate { get; set; }
    }
}