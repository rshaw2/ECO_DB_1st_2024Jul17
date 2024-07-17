using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a organizationsettingsfile entity with essential details
    /// </summary>
    public class OrganizationSettingsFile
    {
        /// <summary>
        /// Primary key for the OrganizationSettingsFile 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the OrganizationSettingsFile belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the OrganizationSettings to which the OrganizationSettingsFile belongs 
        /// </summary>
        [Required]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated OrganizationSettings
        /// </summary>
        [ForeignKey("OrganizationId")]
        public OrganizationSettings? OrganizationId_OrganizationSettings { get; set; }

        /// <summary>
        /// Required field OrganizationFileType of the OrganizationSettingsFile 
        /// </summary>
        [Required]
        public byte OrganizationFileType { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the OrganizationSettingsFile belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the OrganizationSettingsFile 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Title of the OrganizationSettingsFile 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the OrganizationSettingsFile 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the OrganizationSettingsFile 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the OrganizationSettingsFile 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the OrganizationSettingsFile 
        /// </summary>
        public string? AzureFilePath { get; set; }
    }
}