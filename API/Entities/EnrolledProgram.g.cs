using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a enrolledprogram entity with essential details
    /// </summary>
    public class EnrolledProgram
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the EnrolledProgram belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the EnrolledProgram 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the LoyaltyProgram to which the EnrolledProgram belongs 
        /// </summary>
        [Required]
        public Guid LoyaltyProgramId { get; set; }

        /// <summary>
        /// Navigation property representing the associated LoyaltyProgram
        /// </summary>
        [ForeignKey("LoyaltyProgramId")]
        public LoyaltyProgram? LoyaltyProgramId_LoyaltyProgram { get; set; }

        /// <summary>
        /// Required field LoyaltyEnrollmenStartDate of the EnrolledProgram 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime LoyaltyEnrollmenStartDate { get; set; }

        /// <summary>
        /// Required field LoyaltyEnrollmenEndDate of the EnrolledProgram 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime LoyaltyEnrollmenEndDate { get; set; }

        /// <summary>
        /// Required field Active of the EnrolledProgram 
        /// </summary>
        [Required]
        public bool Active { get; set; }
    }
}