using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a diagnosissuggestion entity with essential details
    /// </summary>
    public class DiagnosisSuggestion
    {
        /// <summary>
        /// Primary key for the DiagnosisSuggestion 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DiagnosisSuggestion belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field DoctorId of the DiagnosisSuggestion 
        /// </summary>
        [Required]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Required field AgeGroup of the DiagnosisSuggestion 
        /// </summary>
        [Required]
        public byte AgeGroup { get; set; }

        /// <summary>
        /// Required field Diagnosis of the DiagnosisSuggestion 
        /// </summary>
        [Required]
        public Guid Diagnosis { get; set; }

        /// <summary>
        /// Required field Weight of the DiagnosisSuggestion 
        /// </summary>
        [Required]
        public int Weight { get; set; }
        /// <summary>
        /// ChiefComplaint of the DiagnosisSuggestion 
        /// </summary>
        public Guid? ChiefComplaint { get; set; }

        /// <summary>
        /// VisitDate of the DiagnosisSuggestion 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? VisitDate { get; set; }
    }
}