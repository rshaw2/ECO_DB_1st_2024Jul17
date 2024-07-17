using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientaccounthistory entity with essential details
    /// </summary>
    public class PatientAccountHistory
    {
        /// <summary>
        /// Primary key for the PatientAccountHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientAccountHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the PatientAccountHistory belongs 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Foreign key referencing the PaymentMode to which the PatientAccountHistory belongs 
        /// </summary>
        [Required]
        public Guid PaymentMode { get; set; }

        /// <summary>
        /// Navigation property representing the associated PaymentMode
        /// </summary>
        [ForeignKey("PaymentMode")]
        public PaymentMode? PaymentMode_PaymentMode { get; set; }

        /// <summary>
        /// Required field PaymentType of the PatientAccountHistory 
        /// </summary>
        [Required]
        public byte PaymentType { get; set; }

        /// <summary>
        /// Required field AccountType of the PatientAccountHistory 
        /// </summary>
        [Required]
        public byte AccountType { get; set; }

        /// <summary>
        /// Required field Amount of the PatientAccountHistory 
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientAccountHistory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientAccountHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientAccountHistory belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdateOn of the PatientAccountHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        /// ReferenceNumber of the PatientAccountHistory 
        /// </summary>
        public string? ReferenceNumber { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the PatientAccountHistory belongs 
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }
    }
}