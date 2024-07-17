using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientcounter entity with essential details
    /// </summary>
    public class PatientCounter
    {
        /// <summary>
        /// Required field Prefix of the PatientCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the PatientCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the PatientCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the PatientCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the PatientCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the PatientCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the PatientCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}