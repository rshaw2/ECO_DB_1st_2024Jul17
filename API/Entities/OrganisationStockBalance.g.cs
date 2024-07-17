using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a organisationstockbalance entity with essential details
    /// </summary>
    public class OrganisationStockBalance
    {
        /// <summary>
        /// Initializes a new instance of the OrganisationStockBalance class.
        /// </summary>
        public OrganisationStockBalance()
        {
            Quantity = 0;
            AgerageCost = 0M;
        }

        /// <summary>
        /// Primary key for the OrganisationStockBalance 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the OrganisationStockBalance belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the OrganisationStockBalance belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field Quantity of the OrganisationStockBalance 
        /// </summary>
        [Required]
        public int Quantity { get; set; }
        /// <summary>
        /// AgerageCost of the OrganisationStockBalance 
        /// </summary>
        public decimal? AgerageCost { get; set; }
    }
}