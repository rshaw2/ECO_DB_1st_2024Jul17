using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a prescriptionfiles entity with essential details
    /// </summary>
    public class PrescriptionFiles
    {
        /// <summary>
        /// Initializes a new instance of the PrescriptionFiles class.
        /// </summary>
        public PrescriptionFiles()
        {
            WithHeaderFooterFormat = false;
        }

        /// <summary>
        /// Foreign key referencing the User to which the PrescriptionFiles belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PrescriptionFiles 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the PrescriptionFiles 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PrescriptionFiles belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the PrescriptionFiles belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Required field VisitCode of the PrescriptionFiles 
        /// </summary>
        [Required]
        public string VisitCode { get; set; }

        /// <summary>
        /// Required field VisitDate of the PrescriptionFiles 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime VisitDate { get; set; }

        /// <summary>
        /// Required field WithHeaderFooterFormat of the PrescriptionFiles 
        /// </summary>
        [Required]
        public bool WithHeaderFooterFormat { get; set; }
        /// <summary>
        /// FileContent of the PrescriptionFiles 
        /// </summary>
        public byte[]? FileContent { get; set; }
        /// <summary>
        /// Title of the PrescriptionFiles 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the PrescriptionFiles 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// MimeType of the PrescriptionFiles 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the PrescriptionFiles 
        /// </summary>
        public string? AzureFilePath { get; set; }
        /// <summary>
        /// FileExtension of the PrescriptionFiles 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// AzureFileMigration of the PrescriptionFiles 
        /// </summary>
        public bool? AzureFileMigration { get; set; }
        /// <summary>
        /// Closed of the PrescriptionFiles 
        /// </summary>
        public bool? Closed { get; set; }
        /// <summary>
        /// Foreign key referencing the Language to which the PrescriptionFiles belongs 
        /// </summary>
        public Guid? LanguageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Language
        /// </summary>
        [ForeignKey("LanguageId")]
        public Language? LanguageId_Language { get; set; }
    }
}