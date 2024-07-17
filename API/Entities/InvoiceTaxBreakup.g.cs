using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a invoicetaxbreakup entity with essential details
    /// </summary>
    public class InvoiceTaxBreakup
    {
        /// <summary>
        /// Primary key for the InvoiceTaxBreakup 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvoiceTaxBreakup belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Invoice to which the InvoiceTaxBreakup belongs 
        /// </summary>
        [Required]
        public Guid Invoice { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("Invoice")]
        public Invoice? Invoice_Invoice { get; set; }

        /// <summary>
        /// Required field TaxPercentage of the InvoiceTaxBreakup 
        /// </summary>
        [Required]
        public decimal TaxPercentage { get; set; }

        /// <summary>
        /// Required field TaxableAmount of the InvoiceTaxBreakup 
        /// </summary>
        [Required]
        public decimal TaxableAmount { get; set; }

        /// <summary>
        /// Required field CgstAmount of the InvoiceTaxBreakup 
        /// </summary>
        [Required]
        public decimal CgstAmount { get; set; }

        /// <summary>
        /// Required field SgstAmount of the InvoiceTaxBreakup 
        /// </summary>
        [Required]
        public decimal SgstAmount { get; set; }

        /// <summary>
        /// Required field IgstAmount of the InvoiceTaxBreakup 
        /// </summary>
        [Required]
        public decimal IgstAmount { get; set; }
    }
}