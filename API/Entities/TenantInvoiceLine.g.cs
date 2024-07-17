using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantinvoiceline entity with essential details
    /// </summary>
    public class TenantInvoiceLine
    {
        /// <summary>
        /// Primary key for the TenantInvoiceLine 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantInvoiceLine belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the TenantInvoice to which the TenantInvoiceLine belongs 
        /// </summary>
        [Required]
        public Guid Invoice { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantInvoice
        /// </summary>
        [ForeignKey("Invoice")]
        public TenantInvoice? Invoice_TenantInvoice { get; set; }

        /// <summary>
        /// Foreign key referencing the Package to which the TenantInvoiceLine belongs 
        /// </summary>
        [Required]
        public Guid PackageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Package
        /// </summary>
        [ForeignKey("PackageId")]
        public Package? PackageId_Package { get; set; }

        /// <summary>
        /// Required field Description of the TenantInvoiceLine 
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Required field Quantity of the TenantInvoiceLine 
        /// </summary>
        [Required]
        public short Quantity { get; set; }

        /// <summary>
        /// Required field UnitPrice of the TenantInvoiceLine 
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Required field Amount of the TenantInvoiceLine 
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TenantInvoiceLine 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field TaxRate of the TenantInvoiceLine 
        /// </summary>
        [Required]
        public short TaxRate { get; set; }

        /// <summary>
        /// Required field TaxAmount of the TenantInvoiceLine 
        /// </summary>
        [Required]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// UpdatedOn of the TenantInvoiceLine 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// DiscountTotal of the TenantInvoiceLine 
        /// </summary>
        public decimal? DiscountTotal { get; set; }
    }
}