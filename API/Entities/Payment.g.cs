using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a payment entity with essential details
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Initializes a new instance of the Payment class.
        /// </summary>
        public Payment()
        {
            IsStandard = false;
            Refund = false;
        }

        /// <summary>
        /// Required field PaymentDate of the Payment 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Required field Amount of the Payment 
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Required field IsStandard of the Payment 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field EntityCode of the Payment 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Payment 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Payment belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Payment 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the Payment 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Payment belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the Payment belongs 
        /// </summary>
        [Required]
        public Guid Patient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("Patient")]
        public Patient? Patient_Patient { get; set; }

        /// <summary>
        /// Foreign key referencing the Invoice to which the Payment belongs 
        /// </summary>
        [Required]
        public Guid Invoice { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("Invoice")]
        public Invoice? Invoice_Invoice { get; set; }

        /// <summary>
        /// Foreign key referencing the PaymentMode to which the Payment belongs 
        /// </summary>
        [Required]
        public Guid PaymentMode { get; set; }

        /// <summary>
        /// Navigation property representing the associated PaymentMode
        /// </summary>
        [ForeignKey("PaymentMode")]
        public PaymentMode? PaymentMode_PaymentMode { get; set; }
        /// <summary>
        /// Code of the Payment 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Payment belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Payment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Name of the Payment 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the Payment 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Refund of the Payment 
        /// </summary>
        public bool? Refund { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the Payment belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// PaidByOther of the Payment 
        /// </summary>
        public bool? PaidByOther { get; set; }
        /// <summary>
        /// PaidByOtherName of the Payment 
        /// </summary>
        public string? PaidByOtherName { get; set; }
    }
}