using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a imagesetting entity with essential details
    /// </summary>
    public class ImageSetting
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ImageSetting belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ImageSetting 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// EntityCode of the ImageSetting 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// FieldName of the ImageSetting 
        /// </summary>
        public string? FieldName { get; set; }
        /// <summary>
        /// Width of the ImageSetting 
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// Height of the ImageSetting 
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// FileSize of the ImageSetting 
        /// </summary>
        public decimal? FileSize { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ImageSetting belongs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// CreatedOn of the ImageSetting 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ImageSetting belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ImageSetting 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}