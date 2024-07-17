using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productcategoryrule entity with essential details
    /// </summary>
    public class ProductCategoryRule
    {
        /// <summary>
        /// Primary key for the ProductCategoryRule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductCategoryRule belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the CoverCategory to which the ProductCategoryRule belongs 
        /// </summary>
        [Required]
        public Guid CoverCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CoverCategory
        /// </summary>
        [ForeignKey("CoverCategoryId")]
        public CoverCategory? CoverCategoryId_CoverCategory { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductCategory to which the ProductCategoryRule belongs 
        /// </summary>
        [Required]
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductCategory
        /// </summary>
        [ForeignKey("ProductCategoryId")]
        public ProductCategory? ProductCategoryId_ProductCategory { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProductCategoryRule belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProductCategoryRule 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProductCategoryRule belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProductCategoryRule 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// MaximumCoverAmount of the ProductCategoryRule 
        /// </summary>
        public decimal? MaximumCoverAmount { get; set; }
        /// <summary>
        /// CoPayAmount of the ProductCategoryRule 
        /// </summary>
        public decimal? CoPayAmount { get; set; }
        /// <summary>
        /// CoPayPercentage of the ProductCategoryRule 
        /// </summary>
        public decimal? CoPayPercentage { get; set; }
        /// <summary>
        /// Deductible of the ProductCategoryRule 
        /// </summary>
        public decimal? Deductible { get; set; }
    }
}