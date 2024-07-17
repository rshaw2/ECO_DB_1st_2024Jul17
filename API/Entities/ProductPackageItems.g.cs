using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productpackageitems entity with essential details
    /// </summary>
    public class ProductPackageItems
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductPackageItems belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ProductPackageItems 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductPackage to which the ProductPackageItems belongs 
        /// </summary>
        [Required]
        public Guid ProductPackageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductPackage
        /// </summary>
        [ForeignKey("ProductPackageId")]
        public ProductPackage? ProductPackageId_ProductPackage { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the ProductPackageItems belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field ProductName of the ProductPackageItems 
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Required field Quantity of the ProductPackageItems 
        /// </summary>
        [Required]
        public byte Quantity { get; set; }

        /// <summary>
        /// Required field Sequence of the ProductPackageItems 
        /// </summary>
        [Required]
        public byte Sequence { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductSchedule to which the ProductPackageItems belongs 
        /// </summary>
        public Guid? ProductScheduleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductSchedule
        /// </summary>
        [ForeignKey("ProductScheduleId")]
        public ProductSchedule? ProductScheduleId_ProductSchedule { get; set; }
    }
}