using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a goodsreturn entity with essential details
    /// </summary>
    public class GoodsReturn
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the GoodsReturn belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the GoodsReturn 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field GrrNumber of the GoodsReturn 
        /// </summary>
        [Required]
        public string GrrNumber { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the GoodsReturn belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the GoodsReturn belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the GoodsReturn 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the GoodsReturn belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the GoodsReturn 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the SubLocation to which the GoodsReturn belongs 
        /// </summary>
        public Guid? SubLocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubLocation
        /// </summary>
        [ForeignKey("SubLocationId")]
        public SubLocation? SubLocationId_SubLocation { get; set; }
        /// <summary>
        /// Foreign key referencing the SubReason to which the GoodsReturn belongs 
        /// </summary>
        public Guid? SubReasonId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubReason
        /// </summary>
        [ForeignKey("SubReasonId")]
        public SubReason? SubReasonId_SubReason { get; set; }
        /// <summary>
        /// Reason of the GoodsReturn 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// ReferrenceNo of the GoodsReturn 
        /// </summary>
        public string? ReferrenceNo { get; set; }

        /// <summary>
        /// ReturnDate of the GoodsReturn 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ReturnDate { get; set; }
        /// <summary>
        /// Foreign key referencing the GoodsReceipt to which the GoodsReturn belongs 
        /// </summary>
        public Guid? GoodsReceiptId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReceipt
        /// </summary>
        [ForeignKey("GoodsReceiptId")]
        public GoodsReceipt? GoodsReceiptId_GoodsReceipt { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the GoodsReturn belongs 
        /// </summary>
        public Guid? SupplierId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("SupplierId")]
        public Contact? SupplierId_Contact { get; set; }
    }
}