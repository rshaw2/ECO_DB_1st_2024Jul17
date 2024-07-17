using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicationinstructiontranslation entity with essential details
    /// </summary>
    public class MedicationInstructionTranslation
    {
        /// <summary>
        /// Primary key for the MedicationInstructionTranslation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the MedicationInstructionTranslation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Language to which the MedicationInstructionTranslation belongs 
        /// </summary>
        [Required]
        public Guid LanguageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Language
        /// </summary>
        [ForeignKey("LanguageId")]
        public Language? LanguageId_Language { get; set; }

        /// <summary>
        /// Foreign key referencing the MedicationInstruction to which the MedicationInstructionTranslation belongs 
        /// </summary>
        [Required]
        public Guid InstructionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated MedicationInstruction
        /// </summary>
        [ForeignKey("InstructionId")]
        public MedicationInstruction? InstructionId_MedicationInstruction { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the MedicationInstructionTranslation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the MedicationInstructionTranslation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the MedicationInstructionTranslation 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// Source of the MedicationInstructionTranslation 
        /// </summary>
        public byte? Source { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the MedicationInstructionTranslation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the MedicationInstructionTranslation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Value of the MedicationInstructionTranslation 
        /// </summary>
        public string? Value { get; set; }
    }
}