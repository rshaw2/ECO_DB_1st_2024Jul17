using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantinvoice entity with essential details
    /// </summary>
    public class TenantInvoice
    {
        /// <summary>
        /// Primary key for the TenantInvoice 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantInvoice belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the TenantSubscription to which the TenantInvoice belongs 
        /// </summary>
        [Required]
        public Guid TenantSubscriptionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantSubscription
        /// </summary>
        [ForeignKey("TenantSubscriptionId")]
        public TenantSubscription? TenantSubscriptionId_TenantSubscription { get; set; }

        /// <summary>
        /// Required field Code of the TenantInvoice 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field GrossAmount of the TenantInvoice 
        /// </summary>
        [Required]
        public decimal GrossAmount { get; set; }

        /// <summary>
        /// Required field NetAmount of the TenantInvoice 
        /// </summary>
        [Required]
        public decimal NetAmount { get; set; }

        /// <summary>
        /// Required field DueAmount of the TenantInvoice 
        /// </summary>
        [Required]
        public decimal DueAmount { get; set; }

        /// <summary>
        /// Required field InvoiceDate of the TenantInvoice 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TenantInvoice 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field InvoiceStatus of the TenantInvoice 
        /// </summary>
        [Required]
        public byte InvoiceStatus { get; set; }
        /// <summary>
        /// Notes of the TenantInvoice 
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// DispatchedThrough of the TenantInvoice 
        /// </summary>
        public string? DispatchedThrough { get; set; }
        /// <summary>
        /// TermsOfDelivery of the TenantInvoice 
        /// </summary>
        public string? TermsOfDelivery { get; set; }
        /// <summary>
        /// HSNCode of the TenantInvoice 
        /// </summary>
        public int? HSNCode { get; set; }
        /// <summary>
        /// TaxRate of the TenantInvoice 
        /// </summary>
        public short? TaxRate { get; set; }
        /// <summary>
        /// TotalTaxAmount of the TenantInvoice 
        /// </summary>
        public decimal? TotalTaxAmount { get; set; }

        /// <summary>
        /// UpdatedOn of the TenantInvoice 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// DueDate of the TenantInvoice 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// DiscountAmount of the TenantInvoice 
        /// </summary>
        public decimal? DiscountAmount { get; set; }
    }
}