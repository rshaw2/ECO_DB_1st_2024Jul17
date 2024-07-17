using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a prescriptionfooter entity with essential details
    /// </summary>
    public class PrescriptionFooter
    {
        /// <summary>
        /// Primary key for the PrescriptionFooter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PrescriptionFooter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the TenantExtension to which the PrescriptionFooter belongs 
        /// </summary>
        [Required]
        public Guid TenantExtensionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantExtension
        /// </summary>
        [ForeignKey("TenantExtensionId")]
        public TenantExtension? TenantExtensionId_TenantExtension { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the PrescriptionFooter belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// FooterAddress of the PrescriptionFooter 
        /// </summary>
        public string? FooterAddress { get; set; }
        /// <summary>
        /// FooterVisitinHour of the PrescriptionFooter 
        /// </summary>
        public string? FooterVisitinHour { get; set; }
    }
}