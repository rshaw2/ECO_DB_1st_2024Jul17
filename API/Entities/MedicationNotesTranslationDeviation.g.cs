using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicationnotestranslationdeviation entity with essential details
    /// </summary>
    public class MedicationNotesTranslationDeviation
    {
        /// <summary>
        /// Primary key for the MedicationNotesTranslationDeviation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the MedicationNotesTranslationDeviation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the MedicationNotesTranslation to which the MedicationNotesTranslationDeviation belongs 
        /// </summary>
        [Required]
        public Guid MedicationNotesTranslationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated MedicationNotesTranslation
        /// </summary>
        [ForeignKey("MedicationNotesTranslationId")]
        public MedicationNotesTranslation? MedicationNotesTranslationId_MedicationNotesTranslation { get; set; }

        /// <summary>
        /// Required field DevationType of the MedicationNotesTranslationDeviation 
        /// </summary>
        [Required]
        public byte DevationType { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the MedicationNotesTranslationDeviation belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}