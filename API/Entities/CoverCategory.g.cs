using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a covercategory entity with essential details
    /// </summary>
    public class CoverCategory
    {
        /// <summary>
        /// Initializes a new instance of the CoverCategory class.
        /// </summary>
        public CoverCategory()
        {
            Disabled = false;
        }

        /// <summary>
        /// Primary key for the CoverCategory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CoverCategory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the CoverCategory 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Code of the CoverCategory 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Foreign key referencing the Contact to which the CoverCategory belongs 
        /// </summary>
        [Required]
        public Guid ContactId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ContactId")]
        public Contact? ContactId_Contact { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CoverCategory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CoverCategory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CoverCategory belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the CoverCategory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// AnnualLimit of the CoverCategory 
        /// </summary>
        public decimal? AnnualLimit { get; set; }
        /// <summary>
        /// MaximumInvoiceLimit of the CoverCategory 
        /// </summary>
        public decimal? MaximumInvoiceLimit { get; set; }
        /// <summary>
        /// MinimumInvoiceLimit of the CoverCategory 
        /// </summary>
        public decimal? MinimumInvoiceLimit { get; set; }
        /// <summary>
        /// InvoiceCoPayAmount of the CoverCategory 
        /// </summary>
        public decimal? InvoiceCoPayAmount { get; set; }
        /// <summary>
        /// Disabled of the CoverCategory 
        /// </summary>
        public bool? Disabled { get; set; }
    }
}