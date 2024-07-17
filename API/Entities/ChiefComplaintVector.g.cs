using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a chiefcomplaintvector entity with essential details
    /// </summary>
    public class ChiefComplaintVector
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ChiefComplaintVector belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ChiefComplaintVector 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the ChiefComplaint to which the ChiefComplaintVector belongs 
        /// </summary>
        [Required]
        public Guid ChiefComplaintId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ChiefComplaint
        /// </summary>
        [ForeignKey("ChiefComplaintId")]
        public ChiefComplaint? ChiefComplaintId_ChiefComplaint { get; set; }

        /// <summary>
        /// Required field VectorValue of the ChiefComplaintVector 
        /// </summary>
        [Required]
        public string VectorValue { get; set; }

        /// <summary>
        /// SyncDate of the ChiefComplaintVector 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SyncDate { get; set; }
    }
}