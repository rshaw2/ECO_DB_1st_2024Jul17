using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a purchaseorder entity with essential details
    /// </summary>
    public class PurchaseOrder
    {
        /// <summary>
        /// Initializes a new instance of the PurchaseOrder class.
        /// </summary>
        public PurchaseOrder()
        {
            InUsed = false;
        }

        /// <summary>
        /// Primary key for the PurchaseOrder 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PurchaseOrder belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Contact to which the PurchaseOrder belongs 
        /// </summary>
        [Required]
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("SupplierId")]
        public Contact? SupplierId_Contact { get; set; }

        /// <summary>
        /// Required field Code of the PurchaseOrder 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field PurchaseOrderDate of the PurchaseOrder 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime PurchaseOrderDate { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the PurchaseOrder belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PurchaseOrder belongs 
        /// </summary>
        [Required]
        public Guid OrderBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("OrderBy")]
        public User? OrderBy_User { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PurchaseOrder belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PurchaseOrder 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PurchaseOrder belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PurchaseOrder 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// InUsed of the PurchaseOrder 
        /// </summary>
        public bool? InUsed { get; set; }
        /// <summary>
        /// ReceivedStatus of the PurchaseOrder 
        /// </summary>
        public byte? ReceivedStatus { get; set; }
        /// <summary>
        /// ReferenceNumber of the PurchaseOrder 
        /// </summary>
        public string? ReferenceNumber { get; set; }

        /// <summary>
        /// ExpectedDeliveryDate of the PurchaseOrder 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpectedDeliveryDate { get; set; }

        /// <summary>
        /// CompletedDate of the PurchaseOrder 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CompletedDate { get; set; }
    }
}