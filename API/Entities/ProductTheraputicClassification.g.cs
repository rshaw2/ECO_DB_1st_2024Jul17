using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a producttheraputicclassification entity with essential details
    /// </summary>
    public class ProductTheraputicClassification
    {
        /// <summary>
        /// Primary key for the ProductTheraputicClassification 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductTheraputicClassification belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the ProductTheraputicClassification belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Foreign key referencing the DrugSystemOrganType to which the ProductTheraputicClassification belongs 
        /// </summary>
        [Required]
        public Guid DrugSystemOrganTypeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugSystemOrganType
        /// </summary>
        [ForeignKey("DrugSystemOrganTypeId")]
        public DrugSystemOrganType? DrugSystemOrganTypeId_DrugSystemOrganType { get; set; }
    }
}