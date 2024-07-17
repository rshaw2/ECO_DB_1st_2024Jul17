using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productuom entity with essential details
    /// </summary>
    public class ProductUom
    {
        /// <summary>
        /// Initializes a new instance of the ProductUom class.
        /// </summary>
        public ProductUom()
        {
            LowestUom = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductUom belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ProductUom 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the ProductUom belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Foreign key referencing the UOM to which the ProductUom belongs 
        /// </summary>
        [Required]
        public Guid UomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("UomId")]
        public UOM? UomId_UOM { get; set; }

        /// <summary>
        /// Required field ConversionQuantity of the ProductUom 
        /// </summary>
        [Required]
        public int ConversionQuantity { get; set; }

        /// <summary>
        /// Required field Purchase of the ProductUom 
        /// </summary>
        [Required]
        public bool Purchase { get; set; }

        /// <summary>
        /// Required field Selling of the ProductUom 
        /// </summary>
        [Required]
        public bool Selling { get; set; }

        /// <summary>
        /// Required field PurchaseDefault of the ProductUom 
        /// </summary>
        [Required]
        public bool PurchaseDefault { get; set; }

        /// <summary>
        /// Required field SellingDefault of the ProductUom 
        /// </summary>
        [Required]
        public bool SellingDefault { get; set; }

        /// <summary>
        /// Required field LowestUom of the ProductUom 
        /// </summary>
        [Required]
        public bool LowestUom { get; set; }
    }
}