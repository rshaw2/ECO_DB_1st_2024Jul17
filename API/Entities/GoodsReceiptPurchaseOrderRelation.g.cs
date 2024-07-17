using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a goodsreceiptpurchaseorderrelation entity with essential details
    /// </summary>
    public class GoodsReceiptPurchaseOrderRelation
    {
        /// <summary>
        /// Primary key for the GoodsReceiptPurchaseOrderRelation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the GoodsReceiptPurchaseOrderRelation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the GoodsReceipt to which the GoodsReceiptPurchaseOrderRelation belongs 
        /// </summary>
        [Required]
        public Guid GoodsReceiptId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReceipt
        /// </summary>
        [ForeignKey("GoodsReceiptId")]
        public GoodsReceipt? GoodsReceiptId_GoodsReceipt { get; set; }

        /// <summary>
        /// Foreign key referencing the PurchaseOrder to which the GoodsReceiptPurchaseOrderRelation belongs 
        /// </summary>
        [Required]
        public Guid PurchaseOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrder
        /// </summary>
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder? PurchaseOrderId_PurchaseOrder { get; set; }
    }
}