using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a pricelistitem entity with essential details
    /// </summary>
    public class PriceListItem
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the PriceListItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PriceListItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PriceList to which the PriceListItem belongs 
        /// </summary>
        [Required]
        public Guid PriceListId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PriceList
        /// </summary>
        [ForeignKey("PriceListId")]
        public PriceList? PriceListId_PriceList { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the PriceListItem belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }
        /// <summary>
        /// Price of the PriceListItem 
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// MarkUpMarkDownValue of the PriceListItem 
        /// </summary>
        public decimal? MarkUpMarkDownValue { get; set; }
        /// <summary>
        /// MarkUpMarkDownUnit of the PriceListItem 
        /// </summary>
        public byte? MarkUpMarkDownUnit { get; set; }
        /// <summary>
        /// Modified of the PriceListItem 
        /// </summary>
        public bool? Modified { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the PriceListItem belongs 
        /// </summary>
        public Guid? ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUomId_ProductUom { get; set; }
    }
}