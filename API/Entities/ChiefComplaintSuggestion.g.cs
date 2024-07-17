using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a chiefcomplaintsuggestion entity with essential details
    /// </summary>
    public class ChiefComplaintSuggestion
    {
        /// <summary>
        /// Primary key for the ChiefComplaintSuggestion 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ChiefComplaintSuggestion belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field DoctorId of the ChiefComplaintSuggestion 
        /// </summary>
        [Required]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Required field AgeGroup of the ChiefComplaintSuggestion 
        /// </summary>
        [Required]
        public byte AgeGroup { get; set; }

        /// <summary>
        /// Required field ChiefComplaint of the ChiefComplaintSuggestion 
        /// </summary>
        [Required]
        public Guid ChiefComplaint { get; set; }

        /// <summary>
        /// Required field Weight of the ChiefComplaintSuggestion 
        /// </summary>
        [Required]
        public int Weight { get; set; }

        /// <summary>
        /// VisitDate of the ChiefComplaintSuggestion 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? VisitDate { get; set; }
    }
}