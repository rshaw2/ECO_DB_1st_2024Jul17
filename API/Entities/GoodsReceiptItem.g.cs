using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a goodsreceiptitem entity with essential details
    /// </summary>
    public class GoodsReceiptItem
    {
        /// <summary>
        /// Initializes a new instance of the GoodsReceiptItem class.
        /// </summary>
        public GoodsReceiptItem()
        {
            TotalCost = 0M;
            LineRejected = false;
            LowestUnitQuantity = 0;
            Bonus = false;
            OrderQuantity = 0;
            RemainingQuantity = 0;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the GoodsReceiptItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the GoodsReceiptItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the GoodsReceipt to which the GoodsReceiptItem belongs 
        /// </summary>
        [Required]
        public Guid GoodsReceiptId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReceipt
        /// </summary>
        [ForeignKey("GoodsReceiptId")]
        public GoodsReceipt? GoodsReceiptId_GoodsReceipt { get; set; }

        /// <summary>
        /// Required field ProductId of the GoodsReceiptItem 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Required field ReceivedQuantity of the GoodsReceiptItem 
        /// </summary>
        [Required]
        public int ReceivedQuantity { get; set; }

        /// <summary>
        /// Required field PackUnitPrice of the GoodsReceiptItem 
        /// </summary>
        [Required]
        public decimal PackUnitPrice { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the GoodsReceiptItem belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the GoodsReceiptItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field TotalCost of the GoodsReceiptItem 
        /// </summary>
        [Required]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Required field LineRejected of the GoodsReceiptItem 
        /// </summary>
        [Required]
        public bool LineRejected { get; set; }

        /// <summary>
        /// Required field LowestUnitQuantity of the GoodsReceiptItem 
        /// </summary>
        [Required]
        public int LowestUnitQuantity { get; set; }

        /// <summary>
        /// Required field Bonus of the GoodsReceiptItem 
        /// </summary>
        [Required]
        public bool Bonus { get; set; }

        /// <summary>
        /// Required field OrderQuantity of the GoodsReceiptItem 
        /// </summary>
        [Required]
        public int OrderQuantity { get; set; }
        /// <summary>
        /// RemainingQuantity of the GoodsReceiptItem 
        /// </summary>
        public int? RemainingQuantity { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the GoodsReceiptItem belongs 
        /// </summary>
        public Guid? ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUomId_ProductUom { get; set; }
        /// <summary>
        /// BatchNumber of the GoodsReceiptItem 
        /// </summary>
        public string? BatchNumber { get; set; }

        /// <summary>
        /// ManufactureDate of the GoodsReceiptItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ManufactureDate { get; set; }

        /// <summary>
        /// ExpiryDate of the GoodsReceiptItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the GoodsReceiptItem belongs 
        /// </summary>
        public Guid? ReplacedProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ReplacedProductId")]
        public Product? ReplacedProductId_Product { get; set; }
        /// <summary>
        /// Reason of the GoodsReceiptItem 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Foreign key referencing the PurchaseOrder to which the GoodsReceiptItem belongs 
        /// </summary>
        public Guid? PurchaseOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrder
        /// </summary>
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder? PurchaseOrderId_PurchaseOrder { get; set; }
        /// <summary>
        /// Foreign key referencing the PurchaseOrderLine to which the GoodsReceiptItem belongs 
        /// </summary>
        public Guid? PurchaseOrderLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrderLine
        /// </summary>
        [ForeignKey("PurchaseOrderLineId")]
        public PurchaseOrderLine? PurchaseOrderLineId_PurchaseOrderLine { get; set; }
        /// <summary>
        /// TaxAmount of the GoodsReceiptItem 
        /// </summary>
        public decimal? TaxAmount { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the GoodsReceiptItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the GoodsReceiptItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductBatch to which the GoodsReceiptItem belongs 
        /// </summary>
        public Guid? ProductBatchId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductBatch
        /// </summary>
        [ForeignKey("ProductBatchId")]
        public ProductBatch? ProductBatchId_ProductBatch { get; set; }
    }
}