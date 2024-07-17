using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicationsuggestion entity with essential details
    /// </summary>
    public class MedicationSuggestion
    {
        /// <summary>
        /// Primary key for the MedicationSuggestion 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the MedicationSuggestion belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field DoctorId of the MedicationSuggestion 
        /// </summary>
        [Required]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Required field AgeGroup of the MedicationSuggestion 
        /// </summary>
        [Required]
        public byte AgeGroup { get; set; }

        /// <summary>
        /// Required field Medication of the MedicationSuggestion 
        /// </summary>
        [Required]
        public Guid Medication { get; set; }

        /// <summary>
        /// Required field Weight of the MedicationSuggestion 
        /// </summary>
        [Required]
        public int Weight { get; set; }
        /// <summary>
        /// Diagnosis of the MedicationSuggestion 
        /// </summary>
        public Guid? Diagnosis { get; set; }

        /// <summary>
        /// VisitDate of the MedicationSuggestion 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? VisitDate { get; set; }
    }
}