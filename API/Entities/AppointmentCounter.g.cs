using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a appointmentcounter entity with essential details
    /// </summary>
    public class AppointmentCounter
    {
        /// <summary>
        /// Required field Prefix of the AppointmentCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the AppointmentCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the AppointmentCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the AppointmentCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the AppointmentCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the AppointmentCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the AppointmentCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}