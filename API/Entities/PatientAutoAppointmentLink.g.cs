using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientautoappointmentlink entity with essential details
    /// </summary>
    public class PatientAutoAppointmentLink
    {
        /// <summary>
        /// Primary key for the PatientAutoAppointmentLink 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientAutoAppointmentLink belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field MobileCountryCode of the PatientAutoAppointmentLink 
        /// </summary>
        [Required]
        public short MobileCountryCode { get; set; }

        /// <summary>
        /// Required field MobileNumber of the PatientAutoAppointmentLink 
        /// </summary>
        [Required]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Required field Link of the PatientAutoAppointmentLink 
        /// </summary>
        [Required]
        public string Link { get; set; }

        /// <summary>
        /// Required field ExpiryDate of the PatientAutoAppointmentLink 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientAutoAppointmentLink belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientAutoAppointmentLink 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Secret of the PatientAutoAppointmentLink 
        /// </summary>
        [Required]
        public string Secret { get; set; }

        /// <summary>
        /// Required field Visited of the PatientAutoAppointmentLink 
        /// </summary>
        [Required]
        public bool Visited { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the PatientAutoAppointmentLink belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientAutoAppointmentLink belongs 
        /// </summary>
        public Guid? DoctorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("DoctorId")]
        public User? DoctorId_User { get; set; }
        /// <summary>
        /// Foreign key referencing the Appointment to which the PatientAutoAppointmentLink belongs 
        /// </summary>
        public Guid? AppointmentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("AppointmentId")]
        public Appointment? AppointmentId_Appointment { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the PatientAutoAppointmentLink belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }
    }
}