using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientcommunication entity with essential details
    /// </summary>
    public class PatientCommunication
    {
        /// <summary>
        /// Initializes a new instance of the PatientCommunication class.
        /// </summary>
        public PatientCommunication()
        {
            Status = false;
        }

        /// <summary>
        /// Primary key for the PatientCommunication 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientCommunication belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the PatientCommunication belongs 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Required field CommunicationType of the PatientCommunication 
        /// </summary>
        [Required]
        public byte CommunicationType { get; set; }

        /// <summary>
        /// Required field CommunicationDate of the PatientCommunication 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CommunicationDate { get; set; }

        /// <summary>
        /// Required field Status of the PatientCommunication 
        /// </summary>
        [Required]
        public bool Status { get; set; }
        /// <summary>
        /// Contents of the PatientCommunication 
        /// </summary>
        public string? Contents { get; set; }
        /// <summary>
        /// Reference of the PatientCommunication 
        /// </summary>
        public string? Reference { get; set; }
    }
}