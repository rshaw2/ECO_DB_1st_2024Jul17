using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a appointmentreminderlog entity with essential details
    /// </summary>
    public class AppointmentReminderLog
    {
        /// <summary>
        /// Initializes a new instance of the AppointmentReminderLog class.
        /// </summary>
        public AppointmentReminderLog()
        {
            EmailStatus = false;
            SMSStatus = false;
            WhatsAppStatus = false;
        }

        /// <summary>
        /// Primary key for the AppointmentReminderLog 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AppointmentReminderLog belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Appointment to which the AppointmentReminderLog belongs 
        /// </summary>
        [Required]
        public Guid AppointmentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("AppointmentId")]
        public Appointment? AppointmentId_Appointment { get; set; }

        /// <summary>
        /// Required field LogDateTime of the AppointmentReminderLog 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime LogDateTime { get; set; }

        /// <summary>
        /// Required field EmailStatus of the AppointmentReminderLog 
        /// </summary>
        [Required]
        public bool EmailStatus { get; set; }

        /// <summary>
        /// Required field SMSStatus of the AppointmentReminderLog 
        /// </summary>
        [Required]
        public bool SMSStatus { get; set; }

        /// <summary>
        /// Required field WhatsAppStatus of the AppointmentReminderLog 
        /// </summary>
        [Required]
        public bool WhatsAppStatus { get; set; }
    }
}