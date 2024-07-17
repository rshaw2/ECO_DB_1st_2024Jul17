using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationlog entity with essential details
    /// </summary>
    public class CommunicationLog
    {
        /// <summary>
        /// Primary key for the CommunicationLog 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationLog belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field CommunicationType of the CommunicationLog 
        /// </summary>
        [Required]
        public byte CommunicationType { get; set; }

        /// <summary>
        /// Required field CommunicationModule of the CommunicationLog 
        /// </summary>
        [Required]
        public byte CommunicationModule { get; set; }

        /// <summary>
        /// Required field CommunicationEvent of the CommunicationLog 
        /// </summary>
        [Required]
        public byte CommunicationEvent { get; set; }

        /// <summary>
        /// Required field CommunicationDateTime of the CommunicationLog 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CommunicationDateTime { get; set; }

        /// <summary>
        /// Required field CommunicationFor of the CommunicationLog 
        /// </summary>
        [Required]
        public byte CommunicationFor { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the CommunicationLog belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CommunicationLog belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CommunicationLog 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field CommunicationStatus of the CommunicationLog 
        /// </summary>
        [Required]
        public byte CommunicationStatus { get; set; }
        /// <summary>
        /// ErrorDescription of the CommunicationLog 
        /// </summary>
        public string? ErrorDescription { get; set; }
        /// <summary>
        /// Refrence of the CommunicationLog 
        /// </summary>
        public string? Refrence { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CommunicationLog belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the CommunicationLog 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the CommunicationLog belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }
        /// <summary>
        /// PatientName of the CommunicationLog 
        /// </summary>
        public string? PatientName { get; set; }
        /// <summary>
        /// PatientMobileNumber of the CommunicationLog 
        /// </summary>
        public string? PatientMobileNumber { get; set; }
        /// <summary>
        /// MobileNumberCountryCode of the CommunicationLog 
        /// </summary>
        public int? MobileNumberCountryCode { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CommunicationLog belongs 
        /// </summary>
        public Guid? DoctorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("DoctorId")]
        public User? DoctorId_User { get; set; }
        /// <summary>
        /// DoctorName of the CommunicationLog 
        /// </summary>
        public string? DoctorName { get; set; }
        /// <summary>
        /// DoctorMobileNumber of the CommunicationLog 
        /// </summary>
        public string? DoctorMobileNumber { get; set; }
        /// <summary>
        /// DoctorMobileNumberCountryCode of the CommunicationLog 
        /// </summary>
        public int? DoctorMobileNumberCountryCode { get; set; }
    }
}