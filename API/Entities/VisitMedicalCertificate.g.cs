using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitmedicalcertificate entity with essential details
    /// </summary>
    public class VisitMedicalCertificate
    {
        /// <summary>
        /// Primary key for the VisitMedicalCertificate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitMedicalCertificate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the VisitMedicalCertificate belongs 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitMedicalCertificate belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Required field FromDate of the VisitMedicalCertificate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitMedicalCertificate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitMedicalCertificate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitMedicalCertificate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitMedicalCertificate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ProductId of the VisitMedicalCertificate 
        /// </summary>
        public Guid? ProductId { get; set; }
        /// <summary>
        /// ProductName of the VisitMedicalCertificate 
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// Foreign key referencing the InvoiceLine to which the VisitMedicalCertificate belongs 
        /// </summary>
        public Guid? InvoiceLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvoiceLine
        /// </summary>
        [ForeignKey("InvoiceLineId")]
        public InvoiceLine? InvoiceLineId_InvoiceLine { get; set; }

        /// <summary>
        /// ToDate of the VisitMedicalCertificate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ToDate { get; set; }
        /// <summary>
        /// Reason of the VisitMedicalCertificate 
        /// </summary>
        public string? Reason { get; set; }
    }
}