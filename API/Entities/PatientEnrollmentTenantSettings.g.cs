using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientenrollmenttenantsettings entity with essential details
    /// </summary>
    public class PatientEnrollmentTenantSettings
    {
        /// <summary>
        /// Initializes a new instance of the PatientEnrollmentTenantSettings class.
        /// </summary>
        public PatientEnrollmentTenantSettings()
        {
            Enable = false;
        }

        /// <summary>
        /// Primary key for the PatientEnrollmentTenantSettings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientEnrollmentTenantSettings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field EnrollmentFeature of the PatientEnrollmentTenantSettings 
        /// </summary>
        [Required]
        public byte EnrollmentFeature { get; set; }

        /// <summary>
        /// Required field Enable of the PatientEnrollmentTenantSettings 
        /// </summary>
        [Required]
        public bool Enable { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientEnrollmentTenantSettings belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientEnrollmentTenantSettings 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientEnrollmentTenantSettings belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdateOn of the PatientEnrollmentTenantSettings 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdateOn { get; set; }
    }
}