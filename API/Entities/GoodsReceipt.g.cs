using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a goodsreceipt entity with essential details
    /// </summary>
    public class GoodsReceipt
    {
        /// <summary>
        /// Foreign key referencing the User to which the GoodsReceipt belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the GoodsReceipt 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the GoodsReceipt belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the GoodsReceipt 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Code of the GoodsReceipt 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the GoodsReceipt belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the GoodsReceipt belongs 
        /// </summary>
        public Guid? SupplierId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("SupplierId")]
        public Contact? SupplierId_Contact { get; set; }

        /// <summary>
        /// ReceivedDate of the GoodsReceipt 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ReceivedDate { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the GoodsReceipt belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the GoodsReceipt 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Reason of the GoodsReceipt 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// GoodsReceiptType of the GoodsReceipt 
        /// </summary>
        public byte? GoodsReceiptType { get; set; }
        /// <summary>
        /// PurchaseOrderNo of the GoodsReceipt 
        /// </summary>
        public string? PurchaseOrderNo { get; set; }
        /// <summary>
        /// ReferenceNumber of the GoodsReceipt 
        /// </summary>
        public string? ReferenceNumber { get; set; }
        /// <summary>
        /// Foreign key referencing the SubLocation to which the GoodsReceipt belongs 
        /// </summary>
        public Guid? SubLocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubLocation
        /// </summary>
        [ForeignKey("SubLocationId")]
        public SubLocation? SubLocationId_SubLocation { get; set; }
    }
}