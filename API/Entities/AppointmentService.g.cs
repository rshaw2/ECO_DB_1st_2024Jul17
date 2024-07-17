using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a appointmentservice entity with essential details
    /// </summary>
    public class AppointmentService
    {
        /// <summary>
        /// Primary key for the AppointmentService 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AppointmentService belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Appointment to which the AppointmentService belongs 
        /// </summary>
        [Required]
        public Guid AppointmentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("AppointmentId")]
        public Appointment? AppointmentId_Appointment { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the AppointmentService belongs 
        /// </summary>
        [Required]
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ServiceId")]
        public Product? ServiceId_Product { get; set; }

        /// <summary>
        /// Required field ServiceName of the AppointmentService 
        /// </summary>
        [Required]
        public string ServiceName { get; set; }
        /// <summary>
        /// Price of the AppointmentService 
        /// </summary>
        public decimal? Price { get; set; }
    }
}