using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitvoicetranscript entity with essential details
    /// </summary>
    public class VisitVoiceTranscript
    {
        /// <summary>
        /// Initializes a new instance of the VisitVoiceTranscript class.
        /// </summary>
        public VisitVoiceTranscript()
        {
            ActiveTranscription = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitVoiceTranscript belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitVoiceTranscript 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitVoiceTranscript belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Required field AudioFileType of the VisitVoiceTranscript 
        /// </summary>
        [Required]
        public string AudioFileType { get; set; }

        /// <summary>
        /// Required field AzurePath of the VisitVoiceTranscript 
        /// </summary>
        [Required]
        public string AzurePath { get; set; }

        /// <summary>
        /// Required field ActiveTranscription of the VisitVoiceTranscript 
        /// </summary>
        [Required]
        public bool ActiveTranscription { get; set; }

        /// <summary>
        /// TranscriptOn of the VisitVoiceTranscript 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TranscriptOn { get; set; }
        /// <summary>
        /// TranscriptedText of the VisitVoiceTranscript 
        /// </summary>
        public string? TranscriptedText { get; set; }
        /// <summary>
        /// TranscriptedResponse of the VisitVoiceTranscript 
        /// </summary>
        public string? TranscriptedResponse { get; set; }
        /// <summary>
        /// TranscriptionToken of the VisitVoiceTranscript 
        /// </summary>
        public short? TranscriptionToken { get; set; }
        /// <summary>
        /// VectorizationToken of the VisitVoiceTranscript 
        /// </summary>
        public short? VectorizationToken { get; set; }
    }
}