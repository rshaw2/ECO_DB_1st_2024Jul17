using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a frequencyvaluetranslation entity with essential details
    /// </summary>
    public class FrequencyValueTranslation
    {
        /// <summary>
        /// Primary key for the FrequencyValueTranslation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the FrequencyValueTranslation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Language to which the FrequencyValueTranslation belongs 
        /// </summary>
        [Required]
        public Guid LanguageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Language
        /// </summary>
        [ForeignKey("LanguageId")]
        public Language? LanguageId_Language { get; set; }

        /// <summary>
        /// Foreign key referencing the FrequencyValue to which the FrequencyValueTranslation belongs 
        /// </summary>
        [Required]
        public Guid FrequencyValueId { get; set; }

        /// <summary>
        /// Navigation property representing the associated FrequencyValue
        /// </summary>
        [ForeignKey("FrequencyValueId")]
        public FrequencyValue? FrequencyValueId_FrequencyValue { get; set; }

        /// <summary>
        /// Required field IsStandard of the FrequencyValueTranslation 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the FrequencyValueTranslation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the FrequencyValueTranslation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the FrequencyValueTranslation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the FrequencyValueTranslation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Source of the FrequencyValueTranslation 
        /// </summary>
        public byte? Source { get; set; }
        /// <summary>
        /// Value of the FrequencyValueTranslation 
        /// </summary>
        public string? Value { get; set; }
    }
}