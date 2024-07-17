using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a packageline entity with essential details
    /// </summary>
    public class PackageLine
    {
        /// <summary>
        /// Primary key for the PackageLine 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Package to which the PackageLine belongs 
        /// </summary>
        [Required]
        public Guid PackageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Package
        /// </summary>
        [ForeignKey("PackageId")]
        public Package? PackageId_Package { get; set; }

        /// <summary>
        /// Required field PackageLineType of the PackageLine 
        /// </summary>
        [Required]
        public byte PackageLineType { get; set; }
        /// <summary>
        /// PackageLineSubType of the PackageLine 
        /// </summary>
        public byte? PackageLineSubType { get; set; }
        /// <summary>
        /// Manageable of the PackageLine 
        /// </summary>
        public bool? Manageable { get; set; }
    }
}