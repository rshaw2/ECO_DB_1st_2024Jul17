using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a subreason entity with essential details
    /// </summary>
    public class SubReason
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the SubReason belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the SubReason 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Name of the SubReason 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the SubReason belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the SubReason 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the SubReason belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the SubReason 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}