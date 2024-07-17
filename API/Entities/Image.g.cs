using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a image entity with essential details
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the Image belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Image 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the Image 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// MimeType of the Image 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// FileSize of the Image 
        /// </summary>
        public decimal? FileSize { get; set; }
        /// <summary>
        /// FileName of the Image 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// Width of the Image 
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// Height of the Image 
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// EntityCode of the Image 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// ParentId of the Image 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the ImageBinary to which the Image belongs 
        /// </summary>
        public Guid? BinaryImageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ImageBinary
        /// </summary>
        [ForeignKey("BinaryImageId")]
        public ImageBinary? BinaryImageId_ImageBinary { get; set; }
        /// <summary>
        /// ThumbnailFileSize of the Image 
        /// </summary>
        public decimal? ThumbnailFileSize { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Image belongs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// CreatedOn of the Image 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Image belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Image 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// FileExtension of the Image 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// AzureFilePath of the Image 
        /// </summary>
        public string? AzureFilePath { get; set; }
        /// <summary>
        /// AzureFilePathThumbnail of the Image 
        /// </summary>
        public string? AzureFilePathThumbnail { get; set; }
        /// <summary>
        /// ThumbnailFileName of the Image 
        /// </summary>
        public string? ThumbnailFileName { get; set; }
    }
}