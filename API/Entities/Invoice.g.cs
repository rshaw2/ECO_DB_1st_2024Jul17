using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a invoice entity with essential details
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Initializes a new instance of the Invoice class.
        /// </summary>
        public Invoice()
        {
            IsStandard = false;
            InvoiceStatus = 0;
        }

        /// <summary>
        /// Required field IsStandard of the Invoice 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field EntityCode of the Invoice 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Invoice 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Invoice belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Invoice 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the Invoice 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Invoice belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the Invoice belongs 
        /// </summary>
        [Required]
        public Guid Patient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("Patient")]
        public Patient? Patient_Patient { get; set; }

        /// <summary>
        /// Required field GrossAmount of the Invoice 
        /// </summary>
        [Required]
        public decimal GrossAmount { get; set; }

        /// <summary>
        /// Required field NetAmount of the Invoice 
        /// </summary>
        [Required]
        public decimal NetAmount { get; set; }

        /// <summary>
        /// Required field DueAmount of the Invoice 
        /// </summary>
        [Required]
        public decimal DueAmount { get; set; }

        /// <summary>
        /// Required field InvoiceStatus of the Invoice 
        /// </summary>
        [Required]
        public byte InvoiceStatus { get; set; }

        /// <summary>
        /// Required field InvoiceDate of the Invoice 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// DueDate of the Invoice 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Foreign key referencing the CoverCategory to which the Invoice belongs 
        /// </summary>
        public Guid? CoverCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CoverCategory
        /// </summary>
        [ForeignKey("CoverCategoryId")]
        public CoverCategory? CoverCategoryId_CoverCategory { get; set; }
        /// <summary>
        /// Foreign key referencing the VoidReason to which the Invoice belongs 
        /// </summary>
        public Guid? VoidReasonId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VoidReason
        /// </summary>
        [ForeignKey("VoidReasonId")]
        public VoidReason? VoidReasonId_VoidReason { get; set; }

        /// <summary>
        /// IssuedDate of the Invoice 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? IssuedDate { get; set; }
        /// <summary>
        /// InvoiceDiscount of the Invoice 
        /// </summary>
        public decimal? InvoiceDiscount { get; set; }
        /// <summary>
        /// DiscountPercentage of the Invoice 
        /// </summary>
        public bool? DiscountPercentage { get; set; }
        /// <summary>
        /// RefundDue of the Invoice 
        /// </summary>
        public decimal? RefundDue { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the Invoice belongs 
        /// </summary>
        public Guid? CreditInvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("CreditInvoiceId")]
        public Invoice? CreditInvoiceId_Invoice { get; set; }
        /// <summary>
        /// CreditNote of the Invoice 
        /// </summary>
        public bool? CreditNote { get; set; }
        /// <summary>
        /// RefundStatus of the Invoice 
        /// </summary>
        public byte? RefundStatus { get; set; }
        /// <summary>
        /// CoPayAmount of the Invoice 
        /// </summary>
        public decimal? CoPayAmount { get; set; }
        /// <summary>
        /// PayorAmount of the Invoice 
        /// </summary>
        public decimal? PayorAmount { get; set; }
        /// <summary>
        /// DiscountAmount of the Invoice 
        /// </summary>
        public decimal? DiscountAmount { get; set; }
        /// <summary>
        /// Code of the Invoice 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the Invoice belongs 
        /// </summary>
        public Guid? Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Invoice belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Invoice 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Name of the Invoice 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the Invoice 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// IsVoid of the Invoice 
        /// </summary>
        public bool? IsVoid { get; set; }
        /// <summary>
        /// InvoiceType of the Invoice 
        /// </summary>
        public byte? InvoiceType { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Invoice belongs 
        /// </summary>
        public Guid? DoctorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("DoctorId")]
        public User? DoctorId_User { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the Invoice belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the Invoice belongs 
        /// </summary>
        public Guid? ReferredById { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ReferredById")]
        public Contact? ReferredById_Contact { get; set; }
        /// <summary>
        /// ReferenceNumber of the Invoice 
        /// </summary>
        public string? ReferenceNumber { get; set; }
        /// <summary>
        /// PayorIsSame of the Invoice 
        /// </summary>
        public bool? PayorIsSame { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the Invoice belongs 
        /// </summary>
        public Guid? PayorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("PayorId")]
        public Contact? PayorId_Contact { get; set; }
        /// <summary>
        /// Foreign key referencing the State to which the Invoice belongs 
        /// </summary>
        public Guid? PlaceOfSupply { get; set; }

        /// <summary>
        /// Navigation property representing the associated State
        /// </summary>
        [ForeignKey("PlaceOfSupply")]
        public State? PlaceOfSupply_State { get; set; }
        /// <summary>
        /// TaxAmount of the Invoice 
        /// </summary>
        public decimal? TaxAmount { get; set; }
        /// <summary>
        /// AmountInText of the Invoice 
        /// </summary>
        public string? AmountInText { get; set; }
        /// <summary>
        /// PaymentStatus of the Invoice 
        /// </summary>
        public byte? PaymentStatus { get; set; }
        /// <summary>
        /// InvoiceBaseType of the Invoice 
        /// </summary>
        public byte? InvoiceBaseType { get; set; }
        /// <summary>
        /// PayorType of the Invoice 
        /// </summary>
        public byte? PayorType { get; set; }
    }
}