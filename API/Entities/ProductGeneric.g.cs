using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productgeneric entity with essential details
    /// </summary>
    public class ProductGeneric
    {
        /// <summary>
        /// Primary key for the ProductGeneric 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductGeneric belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the ProductGeneric 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the ProductGeneric belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Foreign key referencing the Generic to which the ProductGeneric belongs 
        /// </summary>
        [Required]
        public Guid GenericId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Generic
        /// </summary>
        [ForeignKey("GenericId")]
        public Generic? GenericId_Generic { get; set; }

        /// <summary>
        /// Foreign key referencing the UOM to which the ProductGeneric belongs 
        /// </summary>
        [Required]
        public Guid UOM { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("UOM")]
        public UOM? UOM_UOM { get; set; }

        /// <summary>
        /// Required field Strength of the ProductGeneric 
        /// </summary>
        [Required]
        public decimal Strength { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProductGeneric belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProductGeneric 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProductGeneric belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProductGeneric 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}