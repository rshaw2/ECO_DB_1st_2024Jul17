using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stocktakeitembatches entity with essential details
    /// </summary>
    public class StockTakeItemBatches
    {
        /// <summary>
        /// Primary key for the StockTakeItemBatches 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the StockTakeItemBatches belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the StockTakeItem to which the StockTakeItemBatches belongs 
        /// </summary>
        [Required]
        public Guid StockTakeItemId { get; set; }

        /// <summary>
        /// Navigation property representing the associated StockTakeItem
        /// </summary>
        [ForeignKey("StockTakeItemId")]
        public StockTakeItem? StockTakeItemId_StockTakeItem { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductBatch to which the StockTakeItemBatches belongs 
        /// </summary>
        [Required]
        public Guid ProductBatchId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductBatch
        /// </summary>
        [ForeignKey("ProductBatchId")]
        public ProductBatch? ProductBatchId_ProductBatch { get; set; }
        /// <summary>
        /// LowestUnitQuantity of the StockTakeItemBatches 
        /// </summary>
        public int? LowestUnitQuantity { get; set; }
        /// <summary>
        /// Variance of the StockTakeItemBatches 
        /// </summary>
        public int? Variance { get; set; }
        /// <summary>
        /// AverageCost of the StockTakeItemBatches 
        /// </summary>
        public decimal? AverageCost { get; set; }
        /// <summary>
        /// VarianceValue of the StockTakeItemBatches 
        /// </summary>
        public decimal? VarianceValue { get; set; }
    }
}