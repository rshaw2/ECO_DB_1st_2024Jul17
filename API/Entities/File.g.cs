using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a file entity with essential details
    /// </summary>
    public class File
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the File belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the File 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the File 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// MimeType of the File 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// FileSize of the File 
        /// </summary>
        public decimal? FileSize { get; set; }
        /// <summary>
        /// FileName of the File 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// EntityCode of the File 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// ParentId of the File 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the FileBinary to which the File belongs 
        /// </summary>
        public Guid? BinaryFileId { get; set; }

        /// <summary>
        /// Navigation property representing the associated FileBinary
        /// </summary>
        [ForeignKey("BinaryFileId")]
        public FileBinary? BinaryFileId_FileBinary { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the File belongs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// CreatedOn of the File 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the File belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the File 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Patient of the File 
        /// </summary>
        public Guid? Patient { get; set; }
        /// <summary>
        /// Category of the File 
        /// </summary>
        public byte? Category { get; set; }
        /// <summary>
        /// FileExtension of the File 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// Notes of the File 
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// AzureDataMigration of the File 
        /// </summary>
        public bool? AzureDataMigration { get; set; }
        /// <summary>
        /// PrescriptionType of the File 
        /// </summary>
        public byte? PrescriptionType { get; set; }
        /// <summary>
        /// PrescriptionDoctorName of the File 
        /// </summary>
        public string? PrescriptionDoctorName { get; set; }

        /// <summary>
        /// OrderDate of the File 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// ResultDate of the File 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ResultDate { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the File belongs 
        /// </summary>
        public Guid? LabId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("LabId")]
        public Contact? LabId_Contact { get; set; }
        /// <summary>
        /// OverAllResult of the File 
        /// </summary>
        public byte? OverAllResult { get; set; }
        /// <summary>
        /// ReferralType of the File 
        /// </summary>
        public byte? ReferralType { get; set; }
        /// <summary>
        /// Referral of the File 
        /// </summary>
        public string? Referral { get; set; }

        /// <summary>
        /// CertificateStartDate of the File 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CertificateStartDate { get; set; }

        /// <summary>
        /// CertificateEndDate of the File 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CertificateEndDate { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the File belongs 
        /// </summary>
        public Guid? VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }
    }
}