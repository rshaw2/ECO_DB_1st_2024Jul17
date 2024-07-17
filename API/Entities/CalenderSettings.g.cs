using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a calendersettings entity with essential details
    /// </summary>
    public class CalenderSettings
    {
        /// <summary>
        /// Initializes a new instance of the CalenderSettings class.
        /// </summary>
        public CalenderSettings()
        {
            TimeUnit = 0;
            PatientCommunication = false;
            DoctorCommunication = false;
        }

        /// <summary>
        /// Primary key for the CalenderSettings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CalenderSettings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }
        /// <summary>
        /// AppointmentDuration of the CalenderSettings 
        /// </summary>
        public byte? AppointmentDuration { get; set; }
        /// <summary>
        /// TimeUnit of the CalenderSettings 
        /// </summary>
        public byte? TimeUnit { get; set; }
        /// <summary>
        /// PatientCommunication of the CalenderSettings 
        /// </summary>
        public bool? PatientCommunication { get; set; }
        /// <summary>
        /// DoctorCommunication of the CalenderSettings 
        /// </summary>
        public bool? DoctorCommunication { get; set; }
    }
}