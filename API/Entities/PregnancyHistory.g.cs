using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a pregnancyhistory entity with essential details
    /// </summary>
    public class PregnancyHistory
    {
        /// <summary>
        /// Primary key for the PregnancyHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PregnancyHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the PregnancyHistory belongs 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Required field CloseDate of the PregnancyHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CloseDate { get; set; }

        /// <summary>
        /// Required field CloseReason of the PregnancyHistory 
        /// </summary>
        [Required]
        public byte CloseReason { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PregnancyHistory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PregnancyHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// PreferenceType of the PregnancyHistory 
        /// </summary>
        public byte? PreferenceType { get; set; }

        /// <summary>
        /// LmpDate of the PregnancyHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LmpDate { get; set; }

        /// <summary>
        /// EddDate of the PregnancyHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EddDate { get; set; }
    }
}