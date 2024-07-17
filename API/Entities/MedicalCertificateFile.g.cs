using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicalcertificatefile entity with essential details
    /// </summary>
    public class MedicalCertificateFile
    {
        /// <summary>
        /// Initializes a new instance of the MedicalCertificateFile class.
        /// </summary>
        public MedicalCertificateFile()
        {
            Print = false;
        }

        /// <summary>
        /// Primary key for the MedicalCertificateFile 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the MedicalCertificateFile belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitMedicalCertificate to which the MedicalCertificateFile belongs 
        /// </summary>
        [Required]
        public Guid MedicalCertificateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitMedicalCertificate
        /// </summary>
        [ForeignKey("MedicalCertificateId")]
        public VisitMedicalCertificate? MedicalCertificateId_VisitMedicalCertificate { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the MedicalCertificateFile belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the MedicalCertificateFile 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Print of the MedicalCertificateFile 
        /// </summary>
        [Required]
        public bool Print { get; set; }
        /// <summary>
        /// Closed of the MedicalCertificateFile 
        /// </summary>
        public bool? Closed { get; set; }
        /// <summary>
        /// MedicalCertificateType of the MedicalCertificateFile 
        /// </summary>
        public byte? MedicalCertificateType { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the MedicalCertificateFile belongs 
        /// </summary>
        public Guid? VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }
        /// <summary>
        /// Title of the MedicalCertificateFile 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the MedicalCertificateFile 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the MedicalCertificateFile 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the MedicalCertificateFile 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the MedicalCertificateFile 
        /// </summary>
        public string? AzureFilePath { get; set; }
    }
}