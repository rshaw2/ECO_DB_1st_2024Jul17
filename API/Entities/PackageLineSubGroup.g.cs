using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a packagelinesubgroup entity with essential details
    /// </summary>
    public class PackageLineSubGroup
    {
        /// <summary>
        /// Primary key for the PackageLineSubGroup 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PackageLine to which the PackageLineSubGroup belongs 
        /// </summary>
        [Required]
        public Guid PackageLine { get; set; }

        /// <summary>
        /// Navigation property representing the associated PackageLine
        /// </summary>
        [ForeignKey("PackageLine")]
        public PackageLine? PackageLine_PackageLine { get; set; }

        /// <summary>
        /// Required field Name of the PackageLineSubGroup 
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}