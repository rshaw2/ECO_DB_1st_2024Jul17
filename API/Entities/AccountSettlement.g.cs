using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a accountsettlement entity with essential details
    /// </summary>
    public class AccountSettlement
    {
        /// <summary>
        /// Primary key for the AccountSettlement 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AccountSettlement belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Appointment to which the AccountSettlement belongs 
        /// </summary>
        [Required]
        public Guid AppointmentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("AppointmentId")]
        public Appointment? AppointmentId_Appointment { get; set; }

        /// <summary>
        /// Foreign key referencing the Invoice to which the AccountSettlement belongs 
        /// </summary>
        [Required]
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }

        /// <summary>
        /// Required field RazorPayTransferId of the AccountSettlement 
        /// </summary>
        [Required]
        public string RazorPayTransferId { get; set; }

        /// <summary>
        /// Required field RazorPayRecipientAccountId of the AccountSettlement 
        /// </summary>
        [Required]
        public string RazorPayRecipientAccountId { get; set; }

        /// <summary>
        /// Required field Amount of the AccountSettlement 
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Required field Currency of the AccountSettlement 
        /// </summary>
        [Required]
        public string Currency { get; set; }

        /// <summary>
        /// Required field RazorPayStatus of the AccountSettlement 
        /// </summary>
        [Required]
        public string RazorPayStatus { get; set; }

        /// <summary>
        /// CreatedDate of the AccountSettlement 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// RazorPaySourceAccountId of the AccountSettlement 
        /// </summary>
        public string? RazorPaySourceAccountId { get; set; }
    }
}