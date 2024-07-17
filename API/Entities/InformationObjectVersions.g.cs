using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a informationobjectversions entity with essential details
    /// </summary>
    public class InformationObjectVersions
    {
        /// <summary>
        /// Primary key for the InformationObjectVersions 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InformationObjectVersions belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the InformationObjects to which the InformationObjectVersions belongs 
        /// </summary>
        [Required]
        public Guid InformationObjectId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InformationObjects
        /// </summary>
        [ForeignKey("InformationObjectId")]
        public InformationObjects? InformationObjectId_InformationObjects { get; set; }

        /// <summary>
        /// Required field VersionNumber of the InformationObjectVersions 
        /// </summary>
        [Required]
        public int VersionNumber { get; set; }

        /// <summary>
        /// Required field VersionDate of the InformationObjectVersions 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime VersionDate { get; set; }

        /// <summary>
        /// Required field Active of the InformationObjectVersions 
        /// </summary>
        [Required]
        public bool Active { get; set; }
    }
}