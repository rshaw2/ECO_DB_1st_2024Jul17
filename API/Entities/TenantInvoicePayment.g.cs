using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantinvoicepayment entity with essential details
    /// </summary>
    public class TenantInvoicePayment
    {
        /// <summary>
        /// Primary key for the TenantInvoicePayment 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantInvoicePayment belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Amount of the TenantInvoicePayment 
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the TenantInvoicePayment belongs 
        /// </summary>
        [Required]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("DoctorId")]
        public User? DoctorId_User { get; set; }

        /// <summary>
        /// Required field RazorPayPaymentLink of the TenantInvoicePayment 
        /// </summary>
        [Required]
        public string RazorPayPaymentLink { get; set; }

        /// <summary>
        /// Required field RazorPayLinkCreated of the TenantInvoicePayment 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime RazorPayLinkCreated { get; set; }

        /// <summary>
        /// Required field RazorPayLinkExpired of the TenantInvoicePayment 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime RazorPayLinkExpired { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TenantInvoicePayment 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// UpdatedOn of the TenantInvoicePayment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// RazorPayRefundId of the TenantInvoicePayment 
        /// </summary>
        public string? RazorPayRefundId { get; set; }

        /// <summary>
        /// RefundDate of the TenantInvoicePayment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? RefundDate { get; set; }
        /// <summary>
        /// RazorPayPaymentId of the TenantInvoicePayment 
        /// </summary>
        public string? RazorPayPaymentId { get; set; }
        /// <summary>
        /// RazorPayPaymentStatus of the TenantInvoicePayment 
        /// </summary>
        public bool? RazorPayPaymentStatus { get; set; }
        /// <summary>
        /// RazorPaymentCapture of the TenantInvoicePayment 
        /// </summary>
        public string? RazorPaymentCapture { get; set; }
        /// <summary>
        /// RazorPayPaymentLinkId of the TenantInvoicePayment 
        /// </summary>
        public string? RazorPayPaymentLinkId { get; set; }
        /// <summary>
        /// RazorPayOrderId of the TenantInvoicePayment 
        /// </summary>
        public string? RazorPayOrderId { get; set; }
        /// <summary>
        /// Foreign key referencing the TenantInvoice to which the TenantInvoicePayment belongs 
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantInvoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public TenantInvoice? InvoiceId_TenantInvoice { get; set; }
    }
}