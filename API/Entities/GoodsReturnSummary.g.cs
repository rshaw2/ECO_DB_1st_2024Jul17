using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a goodsreturnsummary entity with essential details
    /// </summary>
    public class GoodsReturnSummary
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the GoodsReturnSummary belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the GoodsReturnSummary 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the GoodsReturnSummary belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field ProductCode of the GoodsReturnSummary 
        /// </summary>
        [Required]
        public string ProductCode { get; set; }

        /// <summary>
        /// Required field ProductName of the GoodsReturnSummary 
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductBatch to which the GoodsReturnSummary belongs 
        /// </summary>
        [Required]
        public Guid ProductBatchId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductBatch
        /// </summary>
        [ForeignKey("ProductBatchId")]
        public ProductBatch? ProductBatchId_ProductBatch { get; set; }

        /// <summary>
        /// Required field BatchNumber of the GoodsReturnSummary 
        /// </summary>
        [Required]
        public string BatchNumber { get; set; }

        /// <summary>
        /// Required field BatchQuantity of the GoodsReturnSummary 
        /// </summary>
        [Required]
        public int BatchQuantity { get; set; }

        /// <summary>
        /// Required field CostPrice of the GoodsReturnSummary 
        /// </summary>
        [Required]
        public decimal CostPrice { get; set; }

        /// <summary>
        /// Required field ReturnDate of the GoodsReturnSummary 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ReturnDate { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the GoodsReturnSummary belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
    }
}