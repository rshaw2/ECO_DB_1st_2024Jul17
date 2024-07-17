using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productrule entity with essential details
    /// </summary>
    public class ProductRule
    {
        /// <summary>
        /// Primary key for the ProductRule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductRule belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the CoverCategory to which the ProductRule belongs 
        /// </summary>
        [Required]
        public Guid CoverCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CoverCategory
        /// </summary>
        [ForeignKey("CoverCategoryId")]
        public CoverCategory? CoverCategoryId_CoverCategory { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the ProductRule belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProductRule belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProductRule 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProductRule belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProductRule 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// MaximumCoverAmount of the ProductRule 
        /// </summary>
        public decimal? MaximumCoverAmount { get; set; }
        /// <summary>
        /// CoPayAmount of the ProductRule 
        /// </summary>
        public decimal? CoPayAmount { get; set; }
        /// <summary>
        /// CoPayPercentage of the ProductRule 
        /// </summary>
        public decimal? CoPayPercentage { get; set; }
        /// <summary>
        /// Deductible of the ProductRule 
        /// </summary>
        public decimal? Deductible { get; set; }
    }
}