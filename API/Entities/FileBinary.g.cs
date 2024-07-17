using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a filebinary entity with essential details
    /// </summary>
    public class FileBinary
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the FileBinary belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the FileBinary 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// FileContent of the FileBinary 
        /// </summary>
        public byte[]? FileContent { get; set; }
        /// <summary>
        /// AzureFilePath of the FileBinary 
        /// </summary>
        public string? AzureFilePath { get; set; }
    }
}