using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productcategorypatientcategoryrule entity with essential details
    /// </summary>
    public class ProductCategoryPatientCategoryRule
    {
        /// <summary>
        /// Primary key for the ProductCategoryPatientCategoryRule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductCategoryPatientCategoryRule belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductCategoryRule to which the ProductCategoryPatientCategoryRule belongs 
        /// </summary>
        [Required]
        public Guid ProductCategoryRuleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductCategoryRule
        /// </summary>
        [ForeignKey("ProductCategoryRuleId")]
        public ProductCategoryRule? ProductCategoryRuleId_ProductCategoryRule { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientCategory to which the ProductCategoryPatientCategoryRule belongs 
        /// </summary>
        [Required]
        public Guid PatientCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientCategory
        /// </summary>
        [ForeignKey("PatientCategoryId")]
        public PatientCategory? PatientCategoryId_PatientCategory { get; set; }
    }
}