using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a dependentinformationobjects entity with essential details
    /// </summary>
    public class DependentInformationObjects
    {
        /// <summary>
        /// Primary key for the DependentInformationObjects 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DependentInformationObjects belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the InformationObjects to which the DependentInformationObjects belongs 
        /// </summary>
        [Required]
        public Guid InformationObjectId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InformationObjects
        /// </summary>
        [ForeignKey("InformationObjectId")]
        public InformationObjects? InformationObjectId_InformationObjects { get; set; }

        /// <summary>
        /// Foreign key referencing the InformationObjects to which the DependentInformationObjects belongs 
        /// </summary>
        [Required]
        public Guid DependentInformationObjectId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InformationObjects
        /// </summary>
        [ForeignKey("DependentInformationObjectId")]
        public InformationObjects? DependentInformationObjectId_InformationObjects { get; set; }
    }
}