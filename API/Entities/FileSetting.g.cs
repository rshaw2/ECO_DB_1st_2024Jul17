using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a filesetting entity with essential details
    /// </summary>
    public class FileSetting
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the FileSetting belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the FileSetting 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// EntityCode of the FileSetting 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// FieldName of the FileSetting 
        /// </summary>
        public string? FieldName { get; set; }
        /// <summary>
        /// FileSize of the FileSetting 
        /// </summary>
        public decimal? FileSize { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the FileSetting belongs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// CreatedOn of the FileSetting 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the FileSetting belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the FileSetting 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// AllowedFileType of the FileSetting 
        /// </summary>
        public string? AllowedFileType { get; set; }
        /// <summary>
        /// RestrictedFileType of the FileSetting 
        /// </summary>
        public string? RestrictedFileType { get; set; }
    }
}