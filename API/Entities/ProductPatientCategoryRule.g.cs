using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productpatientcategoryrule entity with essential details
    /// </summary>
    public class ProductPatientCategoryRule
    {
        /// <summary>
        /// Primary key for the ProductPatientCategoryRule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductPatientCategoryRule belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductRule to which the ProductPatientCategoryRule belongs 
        /// </summary>
        [Required]
        public Guid ProductRuleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductRule
        /// </summary>
        [ForeignKey("ProductRuleId")]
        public ProductRule? ProductRuleId_ProductRule { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientCategory to which the ProductPatientCategoryRule belongs 
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