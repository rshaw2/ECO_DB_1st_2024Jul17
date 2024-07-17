using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicationinstructiontranslationdeviation entity with essential details
    /// </summary>
    public class MedicationInstructionTranslationDeviation
    {
        /// <summary>
        /// Primary key for the MedicationInstructionTranslationDeviation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the MedicationInstructionTranslationDeviation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the MedicationInstructionTranslation to which the MedicationInstructionTranslationDeviation belongs 
        /// </summary>
        [Required]
        public Guid MedicationInstructionTranslationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated MedicationInstructionTranslation
        /// </summary>
        [ForeignKey("MedicationInstructionTranslationId")]
        public MedicationInstructionTranslation? MedicationInstructionTranslationId_MedicationInstructionTranslation { get; set; }

        /// <summary>
        /// Required field DevationType of the MedicationInstructionTranslationDeviation 
        /// </summary>
        [Required]
        public byte DevationType { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the MedicationInstructionTranslationDeviation belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}