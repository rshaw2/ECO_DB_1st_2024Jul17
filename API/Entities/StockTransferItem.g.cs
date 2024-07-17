using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stocktransferitem entity with essential details
    /// </summary>
    public class StockTransferItem
    {
        /// <summary>
        /// Initializes a new instance of the StockTransferItem class.
        /// </summary>
        public StockTransferItem()
        {
            TransferUomType = 0;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the StockTransferItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the StockTransferItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the StockTransfer to which the StockTransferItem belongs 
        /// </summary>
        [Required]
        public Guid StockTransferId { get; set; }

        /// <summary>
        /// Navigation property representing the associated StockTransfer
        /// </summary>
        [ForeignKey("StockTransferId")]
        public StockTransfer? StockTransferId_StockTransfer { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the StockTransferItem belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field TransferQuantity of the StockTransferItem 
        /// </summary>
        [Required]
        public int TransferQuantity { get; set; }

        /// <summary>
        /// Required field UnitPrice of the StockTransferItem 
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Required field TransferUomType of the StockTransferItem 
        /// </summary>
        [Required]
        public byte TransferUomType { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the StockTransferItem belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the StockTransferItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the StockTransferItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the StockTransferItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// NewQoh of the StockTransferItem 
        /// </summary>
        public int? NewQoh { get; set; }
        /// <summary>
        /// TransferAmount of the StockTransferItem 
        /// </summary>
        public decimal? TransferAmount { get; set; }
        /// <summary>
        /// LineRejected of the StockTransferItem 
        /// </summary>
        public bool? LineRejected { get; set; }
        /// <summary>
        /// Reason of the StockTransferItem 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductBatch to which the StockTransferItem belongs 
        /// </summary>
        public Guid? ProductBatchId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductBatch
        /// </summary>
        [ForeignKey("ProductBatchId")]
        public ProductBatch? ProductBatchId_ProductBatch { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the StockTransferItem belongs 
        /// </summary>
        public Guid? ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUomId_ProductUom { get; set; }
    }
}