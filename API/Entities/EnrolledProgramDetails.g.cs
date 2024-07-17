using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a enrolledprogramdetails entity with essential details
    /// </summary>
    public class EnrolledProgramDetails
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the EnrolledProgramDetails belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the EnrolledProgramDetails 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the EnrolledProgram to which the EnrolledProgramDetails belongs 
        /// </summary>
        [Required]
        public Guid EnrolledProgramId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EnrolledProgram
        /// </summary>
        [ForeignKey("EnrolledProgramId")]
        public EnrolledProgram? EnrolledProgramId_EnrolledProgram { get; set; }

        /// <summary>
        /// Required field CreatedOn of the EnrolledProgramDetails 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EnrollmentStatus of the EnrolledProgramDetails 
        /// </summary>
        [Required]
        public short EnrollmentStatus { get; set; }
        /// <summary>
        /// ZohoLeadId of the EnrolledProgramDetails 
        /// </summary>
        public string? ZohoLeadId { get; set; }
        /// <summary>
        /// Name of the EnrolledProgramDetails 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Phone of the EnrolledProgramDetails 
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// CountryCode of the EnrolledProgramDetails 
        /// </summary>
        public short? CountryCode { get; set; }
        /// <summary>
        /// EmailAddress of the EnrolledProgramDetails 
        /// </summary>
        public string? EmailAddress { get; set; }
        /// <summary>
        /// GoogleReview of the EnrolledProgramDetails 
        /// </summary>
        public bool? GoogleReview { get; set; }
        /// <summary>
        /// Usage of the EnrolledProgramDetails 
        /// </summary>
        public int? Usage { get; set; }
    }
}