using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productcategory entity with essential details
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Initializes a new instance of the ProductCategory class.
        /// </summary>
        public ProductCategory()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Required field Name of the ProductCategory 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field IsStandard of the ProductCategory 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProductCategory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProductCategory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductCategory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ProductCategory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the ProductCategory 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProductCategory belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProductCategory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ProductType of the ProductCategory 
        /// </summary>
        public byte? ProductType { get; set; }
        /// <summary>
        /// Enabled of the ProductCategory 
        /// </summary>
        public bool? Enabled { get; set; }
        /// <summary>
        /// MappedToSupplier of the ProductCategory 
        /// </summary>
        public bool? MappedToSupplier { get; set; }
        /// <summary>
        /// CanHaveInventory of the ProductCategory 
        /// </summary>
        public bool? CanHaveInventory { get; set; }
    }
}