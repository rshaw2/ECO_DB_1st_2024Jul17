using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productgenderrule entity with essential details
    /// </summary>
    public class ProductGenderRule
    {
        /// <summary>
        /// Primary key for the ProductGenderRule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductGenderRule belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductRule to which the ProductGenderRule belongs 
        /// </summary>
        [Required]
        public Guid ProductRuleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductRule
        /// </summary>
        [ForeignKey("ProductRuleId")]
        public ProductRule? ProductRuleId_ProductRule { get; set; }

        /// <summary>
        /// Foreign key referencing the Gender to which the ProductGenderRule belongs 
        /// </summary>
        [Required]
        public Guid GenderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Gender
        /// </summary>
        [ForeignKey("GenderId")]
        public Gender? GenderId_Gender { get; set; }

        /// <summary>
        /// Required field AgeFrom of the ProductGenderRule 
        /// </summary>
        [Required]
        public short AgeFrom { get; set; }

        /// <summary>
        /// Required field AgeTo of the ProductGenderRule 
        /// </summary>
        [Required]
        public short AgeTo { get; set; }
    }
}