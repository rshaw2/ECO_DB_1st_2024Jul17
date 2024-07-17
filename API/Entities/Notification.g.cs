using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a notification entity with essential details
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Initializes a new instance of the Notification class.
        /// </summary>
        public Notification()
        {
            Dismiss = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Notification belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Notification 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Appointment to which the Notification belongs 
        /// </summary>
        [Required]
        public Guid Appointment { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("Appointment")]
        public Appointment? Appointment_Appointment { get; set; }

        /// <summary>
        /// Required field DueDate of the Notification 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Required field Dismiss of the Notification 
        /// </summary>
        [Required]
        public bool Dismiss { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Notification belongs 
        /// </summary>
        [Required]
        public Guid Recipient { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("Recipient")]
        public User? Recipient_User { get; set; }
    }
}