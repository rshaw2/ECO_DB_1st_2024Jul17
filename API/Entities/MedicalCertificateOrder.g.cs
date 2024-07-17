using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicalcertificateorder entity with essential details
    /// </summary>
    public class MedicalCertificateOrder
    {
        /// <summary>
        /// Primary key for the MedicalCertificateOrder 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the MedicalCertificateOrder belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field OrderNumber of the MedicalCertificateOrder 
        /// </summary>
        [Required]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the MedicalCertificateOrder belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Required field OrderLineStatus of the MedicalCertificateOrder 
        /// </summary>
        [Required]
        public Guid OrderLineStatus { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitMedicalCertificate to which the MedicalCertificateOrder belongs 
        /// </summary>
        [Required]
        public Guid VisitMedicalCertificateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitMedicalCertificate
        /// </summary>
        [ForeignKey("VisitMedicalCertificateId")]
        public VisitMedicalCertificate? VisitMedicalCertificateId_VisitMedicalCertificate { get; set; }

        /// <summary>
        /// Required field InvoiceStatus of the MedicalCertificateOrder 
        /// </summary>
        [Required]
        public byte InvoiceStatus { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the MedicalCertificateOrder belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the MedicalCertificateOrder 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the MedicalCertificateOrder belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the MedicalCertificateOrder 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the InvoiceLine to which the MedicalCertificateOrder belongs 
        /// </summary>
        public Guid? InvoiceLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvoiceLine
        /// </summary>
        [ForeignKey("InvoiceLineId")]
        public InvoiceLine? InvoiceLineId_InvoiceLine { get; set; }
    }
}