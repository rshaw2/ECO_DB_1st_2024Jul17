using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a invoicefiles entity with essential details
    /// </summary>
    public class InvoiceFiles
    {
        /// <summary>
        /// Initializes a new instance of the InvoiceFiles class.
        /// </summary>
        public InvoiceFiles()
        {
            FileType = 1;
            Paid = false;
        }

        /// <summary>
        /// Foreign key referencing the User to which the InvoiceFiles belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InvoiceFiles 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the InvoiceFiles 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvoiceFiles belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Invoice to which the InvoiceFiles belongs 
        /// </summary>
        [Required]
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }

        /// <summary>
        /// Required field InvoiceCode of the InvoiceFiles 
        /// </summary>
        [Required]
        public string InvoiceCode { get; set; }

        /// <summary>
        /// Required field FileType of the InvoiceFiles 
        /// </summary>
        [Required]
        public byte FileType { get; set; }

        /// <summary>
        /// InvoiceDate of the InvoiceFiles 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// FileContent of the InvoiceFiles 
        /// </summary>
        public byte[]? FileContent { get; set; }
        /// <summary>
        /// Title of the InvoiceFiles 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the InvoiceFiles 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the InvoiceFiles 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the InvoiceFiles 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the InvoiceFiles 
        /// </summary>
        public string? AzureFilePath { get; set; }
        /// <summary>
        /// Paid of the InvoiceFiles 
        /// </summary>
        public bool? Paid { get; set; }
    }
}