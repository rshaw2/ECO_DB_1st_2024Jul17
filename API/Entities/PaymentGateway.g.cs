using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a paymentgateway entity with essential details
    /// </summary>
    public class PaymentGateway
    {
        /// <summary>
        /// Primary key for the PaymentGateway 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PaymentGateway belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Appointment to which the PaymentGateway belongs 
        /// </summary>
        [Required]
        public Guid AppointmentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("AppointmentId")]
        public Appointment? AppointmentId_Appointment { get; set; }

        /// <summary>
        /// Required field Amount of the PaymentGateway 
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PaymentGateway belongs 
        /// </summary>
        [Required]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("DoctorId")]
        public User? DoctorId_User { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the PaymentGateway belongs 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Required field RazorPayPaymentLink of the PaymentGateway 
        /// </summary>
        [Required]
        public string RazorPayPaymentLink { get; set; }

        /// <summary>
        /// Required field RazorPayLinkCreated of the PaymentGateway 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime RazorPayLinkCreated { get; set; }

        /// <summary>
        /// Required field RazorPayLinkExpired of the PaymentGateway 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime RazorPayLinkExpired { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PaymentGateway belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PaymentGateway 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// UpdatedOn of the PaymentGateway 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// RazorPayRefundId of the PaymentGateway 
        /// </summary>
        public string? RazorPayRefundId { get; set; }

        /// <summary>
        /// RefundDate of the PaymentGateway 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? RefundDate { get; set; }
        /// <summary>
        /// RazorPayPaymentId of the PaymentGateway 
        /// </summary>
        public string? RazorPayPaymentId { get; set; }
        /// <summary>
        /// RazorPayPaymentStatus of the PaymentGateway 
        /// </summary>
        public bool? RazorPayPaymentStatus { get; set; }
        /// <summary>
        /// RazorPaymentCapture of the PaymentGateway 
        /// </summary>
        public string? RazorPaymentCapture { get; set; }
        /// <summary>
        /// RazorPayPaymentLinkId of the PaymentGateway 
        /// </summary>
        public string? RazorPayPaymentLinkId { get; set; }
        /// <summary>
        /// RazorPayOrderId of the PaymentGateway 
        /// </summary>
        public string? RazorPayOrderId { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the PaymentGateway belongs 
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }
    }
}