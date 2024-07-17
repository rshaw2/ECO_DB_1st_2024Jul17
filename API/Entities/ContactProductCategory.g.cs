using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contactproductcategory entity with essential details
    /// </summary>
    public class ContactProductCategory
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ContactProductCategory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ContactProductCategory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Contact to which the ContactProductCategory belongs 
        /// </summary>
        [Required]
        public Guid ContactId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ContactId")]
        public Contact? ContactId_Contact { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductCategory to which the ContactProductCategory belongs 
        /// </summary>
        [Required]
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductCategory
        /// </summary>
        [ForeignKey("ProductCategoryId")]
        public ProductCategory? ProductCategoryId_ProductCategory { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ContactProductCategory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ContactProductCategory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ContactProductCategory belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ContactProductCategory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}