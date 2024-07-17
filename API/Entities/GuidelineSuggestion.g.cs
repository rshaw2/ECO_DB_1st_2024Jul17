using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a guidelinesuggestion entity with essential details
    /// </summary>
    public class GuidelineSuggestion
    {
        /// <summary>
        /// Primary key for the GuidelineSuggestion 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the GuidelineSuggestion belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field DoctorId of the GuidelineSuggestion 
        /// </summary>
        [Required]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Required field AgeGroup of the GuidelineSuggestion 
        /// </summary>
        [Required]
        public byte AgeGroup { get; set; }

        /// <summary>
        /// Required field Guideline of the GuidelineSuggestion 
        /// </summary>
        [Required]
        public Guid Guideline { get; set; }

        /// <summary>
        /// Required field Weight of the GuidelineSuggestion 
        /// </summary>
        [Required]
        public int Weight { get; set; }
        /// <summary>
        /// Diagnosis of the GuidelineSuggestion 
        /// </summary>
        public Guid? Diagnosis { get; set; }

        /// <summary>
        /// VisitDate of the GuidelineSuggestion 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? VisitDate { get; set; }
    }
}