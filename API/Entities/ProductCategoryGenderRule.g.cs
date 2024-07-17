using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productcategorygenderrule entity with essential details
    /// </summary>
    public class ProductCategoryGenderRule
    {
        /// <summary>
        /// Primary key for the ProductCategoryGenderRule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductCategoryGenderRule belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductCategoryRule to which the ProductCategoryGenderRule belongs 
        /// </summary>
        [Required]
        public Guid ProductCategoryRuleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductCategoryRule
        /// </summary>
        [ForeignKey("ProductCategoryRuleId")]
        public ProductCategoryRule? ProductCategoryRuleId_ProductCategoryRule { get; set; }

        /// <summary>
        /// Foreign key referencing the Gender to which the ProductCategoryGenderRule belongs 
        /// </summary>
        [Required]
        public Guid GenderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Gender
        /// </summary>
        [ForeignKey("GenderId")]
        public Gender? GenderId_Gender { get; set; }

        /// <summary>
        /// Required field AgeFrom of the ProductCategoryGenderRule 
        /// </summary>
        [Required]
        public short AgeFrom { get; set; }

        /// <summary>
        /// Required field AgeTo of the ProductCategoryGenderRule 
        /// </summary>
        [Required]
        public short AgeTo { get; set; }
    }
}