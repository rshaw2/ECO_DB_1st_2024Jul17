using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a emrsuggestionlog entity with essential details
    /// </summary>
    public class EMRSuggestionLog
    {
        /// <summary>
        /// Primary key for the EMRSuggestionLog 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the EMRSuggestionLog belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the EMRSuggestionLog belongs 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the EMRSuggestionLog belongs 
        /// </summary>
        [Required]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("DoctorId")]
        public User? DoctorId_User { get; set; }

        /// <summary>
        /// Required field AgeGroup of the EMRSuggestionLog 
        /// </summary>
        [Required]
        public byte AgeGroup { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the EMRSuggestionLog belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Required field RequestedDate of the EMRSuggestionLog 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime RequestedDate { get; set; }
        /// <summary>
        /// ResponseData of the EMRSuggestionLog 
        /// </summary>
        public string? ResponseData { get; set; }
        /// <summary>
        /// Foreign key referencing the ChiefComplaint to which the EMRSuggestionLog belongs 
        /// </summary>
        public Guid? ChiefComplaintId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ChiefComplaint
        /// </summary>
        [ForeignKey("ChiefComplaintId")]
        public ChiefComplaint? ChiefComplaintId_ChiefComplaint { get; set; }
        /// <summary>
        /// Foreign key referencing the Diagnosis to which the EMRSuggestionLog belongs 
        /// </summary>
        public Guid? DiagnosisId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Diagnosis
        /// </summary>
        [ForeignKey("DiagnosisId")]
        public Diagnosis? DiagnosisId_Diagnosis { get; set; }
    }
}