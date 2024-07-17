using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a packagelinesubgroupfeature entity with essential details
    /// </summary>
    public class PackageLineSubGroupFeature
    {
        /// <summary>
        /// Primary key for the PackageLineSubGroupFeature 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PackageLineSubGroup to which the PackageLineSubGroupFeature belongs 
        /// </summary>
        [Required]
        public Guid PackageLineSubGroup { get; set; }

        /// <summary>
        /// Navigation property representing the associated PackageLineSubGroup
        /// </summary>
        [ForeignKey("PackageLineSubGroup")]
        public PackageLineSubGroup? PackageLineSubGroup_PackageLineSubGroup { get; set; }

        /// <summary>
        /// Required field Name of the PackageLineSubGroupFeature 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Code of the PackageLineSubGroupFeature 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field Enabled of the PackageLineSubGroupFeature 
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Required field Configurable of the PackageLineSubGroupFeature 
        /// </summary>
        [Required]
        public bool Configurable { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the PackageLineSubGroupFeature belongs 
        /// </summary>
        public Guid? FeatureParameterId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("FeatureParameterId")]
        public ClinicalParameter? FeatureParameterId_ClinicalParameter { get; set; }
    }
}