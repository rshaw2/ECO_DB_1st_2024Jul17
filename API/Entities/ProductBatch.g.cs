using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productbatch entity with essential details
    /// </summary>
    public class ProductBatch
    {
        /// <summary>
        /// Initializes a new instance of the ProductBatch class.
        /// </summary>
        public ProductBatch()
        {
            PackReceiptQuantity = 0;
            AverageCost = 0M;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductBatch belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ProductBatch 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the ProductBatch belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the ProductBatch belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field PurchaseValue of the ProductBatch 
        /// </summary>
        [Required]
        public decimal PurchaseValue { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductUom to which the ProductBatch belongs 
        /// </summary>
        [Required]
        public Guid ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUomId_ProductUom { get; set; }

        /// <summary>
        /// Required field BatchNumber of the ProductBatch 
        /// </summary>
        [Required]
        public string BatchNumber { get; set; }

        /// <summary>
        /// Required field BatchQuantity of the ProductBatch 
        /// </summary>
        [Required]
        public int BatchQuantity { get; set; }

        /// <summary>
        /// Required field PackReceiptQuantity of the ProductBatch 
        /// </summary>
        [Required]
        public int PackReceiptQuantity { get; set; }

        /// <summary>
        /// Required field PackUnitPrice of the ProductBatch 
        /// </summary>
        [Required]
        public decimal PackUnitPrice { get; set; }

        /// <summary>
        /// Required field UnitPrice of the ProductBatch 
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Required field ExpiryDate of the ProductBatch 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Required field ManufactureDate of the ProductBatch 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ManufactureDate { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProductBatch 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProductBatch belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field AverageCost of the ProductBatch 
        /// </summary>
        [Required]
        public decimal AverageCost { get; set; }
        /// <summary>
        /// Foreign key referencing the SubLocation to which the ProductBatch belongs 
        /// </summary>
        public Guid? SubLocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubLocation
        /// </summary>
        [ForeignKey("SubLocationId")]
        public SubLocation? SubLocationId_SubLocation { get; set; }
        /// <summary>
        /// Import of the ProductBatch 
        /// </summary>
        public bool? Import { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProductBatch belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProductBatch 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}