using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cashregisterhistory entity with essential details
    /// </summary>
    public class CashRegisterHistory
    {
        /// <summary>
        /// Primary key for the CashRegisterHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CashRegisterHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the CashRegister to which the CashRegisterHistory belongs 
        /// </summary>
        [Required]
        public Guid CashRegisterId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CashRegister
        /// </summary>
        [ForeignKey("CashRegisterId")]
        public CashRegister? CashRegisterId_CashRegister { get; set; }

        /// <summary>
        /// Required field TransactionType of the CashRegisterHistory 
        /// </summary>
        [Required]
        public byte TransactionType { get; set; }

        /// <summary>
        /// Required field Amount of the CashRegisterHistory 
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Required field TransactionFrom of the CashRegisterHistory 
        /// </summary>
        [Required]
        public byte TransactionFrom { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CashRegisterHistory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CashRegisterHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the CashRegisterHistory belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the CashRegisterHistory belongs 
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }
        /// <summary>
        /// Foreign key referencing the CashRegisterReason to which the CashRegisterHistory belongs 
        /// </summary>
        public Guid? CashRegisterReasonId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CashRegisterReason
        /// </summary>
        [ForeignKey("CashRegisterReasonId")]
        public CashRegisterReason? CashRegisterReasonId_CashRegisterReason { get; set; }
        /// <summary>
        /// Reason of the CashRegisterHistory 
        /// </summary>
        public string? Reason { get; set; }
    }
}