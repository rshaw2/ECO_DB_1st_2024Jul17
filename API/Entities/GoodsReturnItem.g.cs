using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a goodsreturnitem entity with essential details
    /// </summary>
    public class GoodsReturnItem
    {
        /// <summary>
        /// Initializes a new instance of the GoodsReturnItem class.
        /// </summary>
        public GoodsReturnItem()
        {
            ReturnUomType = 0;
        }

        /// <summary>
        /// Required field UnitPrice of the GoodsReturnItem 
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Required field ReturnQuantity of the GoodsReturnItem 
        /// </summary>
        [Required]
        public int ReturnQuantity { get; set; }

        /// <summary>
        /// Required field ReturnUomType of the GoodsReturnItem 
        /// </summary>
        [Required]
        public byte ReturnUomType { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the GoodsReturnItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the GoodsReturnItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the GoodsReturn to which the GoodsReturnItem belongs 
        /// </summary>
        [Required]
        public Guid GoodsReturnId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReturn
        /// </summary>
        [ForeignKey("GoodsReturnId")]
        public GoodsReturn? GoodsReturnId_GoodsReturn { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the GoodsReturnItem belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the GoodsReturnItem belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the GoodsReturnItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the GoodsReturnItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the GoodsReturnItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductBatch to which the GoodsReturnItem belongs 
        /// </summary>
        public Guid? ProductBatchId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductBatch
        /// </summary>
        [ForeignKey("ProductBatchId")]
        public ProductBatch? ProductBatchId_ProductBatch { get; set; }
        /// <summary>
        /// Foreign key referencing the GoodsReceiptItem to which the GoodsReturnItem belongs 
        /// </summary>
        public Guid? GoodsReceiptItemId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReceiptItem
        /// </summary>
        [ForeignKey("GoodsReceiptItemId")]
        public GoodsReceiptItem? GoodsReceiptItemId_GoodsReceiptItem { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the GoodsReturnItem belongs 
        /// </summary>
        public Guid? ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUomId_ProductUom { get; set; }
        /// <summary>
        /// RemainingQuantity of the GoodsReturnItem 
        /// </summary>
        public int? RemainingQuantity { get; set; }
        /// <summary>
        /// TotalQuantity of the GoodsReturnItem 
        /// </summary>
        public int? TotalQuantity { get; set; }
        /// <summary>
        /// TotalAmount of the GoodsReturnItem 
        /// </summary>
        public decimal? TotalAmount { get; set; }
        /// <summary>
        /// LineRejected of the GoodsReturnItem 
        /// </summary>
        public bool? LineRejected { get; set; }
        /// <summary>
        /// Reason of the GoodsReturnItem 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Foreign key referencing the SubReason to which the GoodsReturnItem belongs 
        /// </summary>
        public Guid? SubReasonId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubReason
        /// </summary>
        [ForeignKey("SubReasonId")]
        public SubReason? SubReasonId_SubReason { get; set; }
    }
}