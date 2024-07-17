using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantinvoicefiles entity with essential details
    /// </summary>
    public class TenantInvoiceFiles
    {
        /// <summary>
        /// Primary key for the TenantInvoiceFiles 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantInvoiceFiles belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the TenantInvoice to which the TenantInvoiceFiles belongs 
        /// </summary>
        [Required]
        public Guid TenantInvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantInvoice
        /// </summary>
        [ForeignKey("TenantInvoiceId")]
        public TenantInvoice? TenantInvoiceId_TenantInvoice { get; set; }

        /// <summary>
        /// Required field InvoiceCode of the TenantInvoiceFiles 
        /// </summary>
        [Required]
        public string InvoiceCode { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TenantInvoiceFiles 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Title of the TenantInvoiceFiles 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the TenantInvoiceFiles 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the TenantInvoiceFiles 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the TenantInvoiceFiles 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the TenantInvoiceFiles 
        /// </summary>
        public string? AzureFilePath { get; set; }
        /// <summary>
        /// Issued of the TenantInvoiceFiles 
        /// </summary>
        public bool? Issued { get; set; }

        /// <summary>
        /// InvoiceDate of the TenantInvoiceFiles 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// FileContent of the TenantInvoiceFiles 
        /// </summary>
        public byte[]? FileContent { get; set; }
    }
}