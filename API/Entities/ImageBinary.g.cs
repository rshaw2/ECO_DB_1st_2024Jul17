using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a imagebinary entity with essential details
    /// </summary>
    public class ImageBinary
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ImageBinary belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ImageBinary 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// ImageId of the ImageBinary 
        /// </summary>
        public Guid? ImageId { get; set; }
        /// <summary>
        /// FileContent of the ImageBinary 
        /// </summary>
        public byte[]? FileContent { get; set; }
        /// <summary>
        /// AzureFilePath of the ImageBinary 
        /// </summary>
        public string? AzureFilePath { get; set; }
        /// <summary>
        /// AzureFilePathThumbnail of the ImageBinary 
        /// </summary>
        public string? AzureFilePathThumbnail { get; set; }
        /// <summary>
        /// ThumbnailFileContent of the ImageBinary 
        /// </summary>
        public byte[]? ThumbnailFileContent { get; set; }
    }
}