using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a guidelinetranslationdeviation entity with essential details
    /// </summary>
    public class GuidelineTranslationDeviation
    {
        /// <summary>
        /// Primary key for the GuidelineTranslationDeviation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the GuidelineTranslationDeviation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the GuidelineTranslation to which the GuidelineTranslationDeviation belongs 
        /// </summary>
        [Required]
        public Guid GuideLineTranslationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GuidelineTranslation
        /// </summary>
        [ForeignKey("GuideLineTranslationId")]
        public GuidelineTranslation? GuideLineTranslationId_GuidelineTranslation { get; set; }

        /// <summary>
        /// Required field DevationType of the GuidelineTranslationDeviation 
        /// </summary>
        [Required]
        public byte DevationType { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the GuidelineTranslationDeviation belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}