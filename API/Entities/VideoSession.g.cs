using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a videosession entity with essential details
    /// </summary>
    public class VideoSession
    {
        /// <summary>
        /// Initializes a new instance of the VideoSession class.
        /// </summary>
        public VideoSession()
        {
            Closed = false;
        }

        /// <summary>
        /// Primary key for the VideoSession 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VideoSession belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field AppointmentId of the VideoSession 
        /// </summary>
        [Required]
        public Guid AppointmentId { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VideoSession belongs 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the VideoSession belongs 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Required field Closed of the VideoSession 
        /// </summary>
        [Required]
        public bool Closed { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the VideoSession belongs 
        /// </summary>
        public Guid? ClosedByPatient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("ClosedByPatient")]
        public Patient? ClosedByPatient_Patient { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VideoSession belongs 
        /// </summary>
        public Guid? ClosedByUser { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("ClosedByUser")]
        public User? ClosedByUser_User { get; set; }
        /// <summary>
        /// RoomName of the VideoSession 
        /// </summary>
        public string? RoomName { get; set; }
        /// <summary>
        /// RoomSid of the VideoSession 
        /// </summary>
        public string? RoomSid { get; set; }

        /// <summary>
        /// StartDate of the VideoSession 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// EndDate of the VideoSession 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
    }
}