using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientenrollmentlink entity with essential details
    /// </summary>
    public class PatientEnrollmentLink
    {
        /// <summary>
        /// Primary key for the PatientEnrollmentLink 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientEnrollmentLink belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field MobileCountryCode of the PatientEnrollmentLink 
        /// </summary>
        [Required]
        public short MobileCountryCode { get; set; }

        /// <summary>
        /// Required field MobileNumber of the PatientEnrollmentLink 
        /// </summary>
        [Required]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Required field Link of the PatientEnrollmentLink 
        /// </summary>
        [Required]
        public string Link { get; set; }

        /// <summary>
        /// Required field ExpiryDateTime of the PatientEnrollmentLink 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ExpiryDateTime { get; set; }

        /// <summary>
        /// Required field Visited of the PatientEnrollmentLink 
        /// </summary>
        [Required]
        public bool Visited { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientEnrollmentLink belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientEnrollmentLink 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Secret of the PatientEnrollmentLink 
        /// </summary>
        [Required]
        public string Secret { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the PatientEnrollmentLink belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }
    }
}