using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a requisitionline entity with essential details
    /// </summary>
    public class RequisitionLine
    {
        /// <summary>
        /// Primary key for the RequisitionLine 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the RequisitionLine belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field RequisitionId of the RequisitionLine 
        /// </summary>
        [Required]
        public Guid RequisitionId { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the RequisitionLine belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field OrderQuantity of the RequisitionLine 
        /// </summary>
        [Required]
        public int OrderQuantity { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductUom to which the RequisitionLine belongs 
        /// </summary>
        [Required]
        public Guid ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUomId_ProductUom { get; set; }

        /// <summary>
        /// Required field TotalQuantity of the RequisitionLine 
        /// </summary>
        [Required]
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the RequisitionLine belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the RequisitionLine 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field RequisitionLineRejected of the RequisitionLine 
        /// </summary>
        [Required]
        public bool RequisitionLineRejected { get; set; }
        /// <summary>
        /// Foreign key referencing the PurchaseOrder to which the RequisitionLine belongs 
        /// </summary>
        public Guid? PurchaseOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrder
        /// </summary>
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder? PurchaseOrderId_PurchaseOrder { get; set; }
        /// <summary>
        /// Foreign key referencing the PurchaseOrderLine to which the RequisitionLine belongs 
        /// </summary>
        public Guid? PurchaseOrderLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrderLine
        /// </summary>
        [ForeignKey("PurchaseOrderLineId")]
        public PurchaseOrderLine? PurchaseOrderLineId_PurchaseOrderLine { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the RequisitionLine belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the RequisitionLine 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Reason of the RequisitionLine 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the RequisitionLine belongs 
        /// </summary>
        public Guid? SupplierId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("SupplierId")]
        public Contact? SupplierId_Contact { get; set; }
    }
}