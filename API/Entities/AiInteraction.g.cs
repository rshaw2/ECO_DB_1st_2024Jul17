using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a aiinteraction entity with essential details
    /// </summary>
    public class AiInteraction
    {
        /// <summary>
        /// Primary key for the AiInteraction 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AiInteraction belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the AiProcess to which the AiInteraction belongs 
        /// </summary>
        [Required]
        public Guid AiProcessId { get; set; }

        /// <summary>
        /// Navigation property representing the associated AiProcess
        /// </summary>
        [ForeignKey("AiProcessId")]
        public AiProcess? AiProcessId_AiProcess { get; set; }

        /// <summary>
        /// Required field Version of the AiInteraction 
        /// </summary>
        [Required]
        public string Version { get; set; }

        /// <summary>
        /// Required field CreatedOn of the AiInteraction 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field SystemRolePrompt of the AiInteraction 
        /// </summary>
        [Required]
        public string SystemRolePrompt { get; set; }

        /// <summary>
        /// Required field UserRolePrompt of the AiInteraction 
        /// </summary>
        [Required]
        public string UserRolePrompt { get; set; }

        /// <summary>
        /// Required field AiResponse of the AiInteraction 
        /// </summary>
        [Required]
        public string AiResponse { get; set; }

        /// <summary>
        /// Required field PromptTokens of the AiInteraction 
        /// </summary>
        [Required]
        public int PromptTokens { get; set; }

        /// <summary>
        /// Required field CompletionTokens of the AiInteraction 
        /// </summary>
        [Required]
        public int CompletionTokens { get; set; }

        /// <summary>
        /// Required field TotalTokens of the AiInteraction 
        /// </summary>
        [Required]
        public int TotalTokens { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the AiInteraction belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }
        /// <summary>
        /// Like of the AiInteraction 
        /// </summary>
        public bool? Like { get; set; }
    }
}