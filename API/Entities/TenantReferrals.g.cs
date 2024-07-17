using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantreferrals entity with essential details
    /// </summary>
    public class TenantReferrals
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantReferrals belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the TenantReferrals 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantReferrals belongs 
        /// </summary>
        [Required]
        public Guid ReferredTenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("ReferredTenantId")]
        public Tenant? ReferredTenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the EnrolledProgram to which the TenantReferrals belongs 
        /// </summary>
        [Required]
        public Guid EnrolledProgramId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EnrolledProgram
        /// </summary>
        [ForeignKey("EnrolledProgramId")]
        public EnrolledProgram? EnrolledProgramId_EnrolledProgram { get; set; }

        /// <summary>
        /// Foreign key referencing the EnrolledProgramDetails to which the TenantReferrals belongs 
        /// </summary>
        [Required]
        public Guid EnrolledProgramDetailsId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EnrolledProgramDetails
        /// </summary>
        [ForeignKey("EnrolledProgramDetailsId")]
        public EnrolledProgramDetails? EnrolledProgramDetailsId_EnrolledProgramDetails { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TenantReferrals 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Enrolled of the TenantReferrals 
        /// </summary>
        public bool? Enrolled { get; set; }

        /// <summary>
        /// EnrollDate of the TenantReferrals 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EnrollDate { get; set; }

        /// <summary>
        /// OnBoardingDate of the TenantReferrals 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? OnBoardingDate { get; set; }
    }
}